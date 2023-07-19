$(()=> {
   
    // Get the button and modal elements
    const button = document.getElementById('reservations');

    let modalBody = $('.sittingModalBody');
    // Add event listener to the button
    button.addEventListener('click', function () {
        
        // Call the getSittings function to fetch sittings
        getSittings();

        // Display the modal
        $("#bookingReservation").modal("show");
    });

    function getSittings() {
       
        modalBody.empty();
        fetch("/api/sittings")
            .then(s => s.json())
            .then(sittings => {
                $('#sittings-container').empty();
                for (let s of sittings) {
                   
                    let startTime = new Date(s.startTime).toLocaleString();
                    let endTime = new Date(s.endTime).toLocaleString();

                    let seatsLeft = s.capacity - s.vacancies;
                    let color = "";
                    if (seatsLeft > s.capacity / 2) {
                        color = "green";
                    } else if (seatsLeft > s.capacity / 4) {
                        color = "#ff9966";
                    } else {
                        color = "red";
                    }

                    let reservation = $(`
                        <div class="reservation">
                          <div class="reservation-name">${s.name}</div>
                          <div class="reservation-time">
                            <div>Start Time: ${startTime}</div>
                            <div>End Time: ${endTime}</div>
                            <div style="color:${color}">${seatsLeft} Seats left!</div>
                          </div>
                        </div>
                      `);

                    reservation.click(() => {
                        const closeButton = document.getElementById('closeButton');
                        closeButton.click();
                        fetchBookingForm(s);

                    });

                    modalBody.append(reservation);
                }
            });
    }

    function fetchBookingForm(sitting) {

        const modal = document.getElementById('bookingReservation');
        $("#bookingReservation").modal("hide");
        $("#bookingReservationForm").modal("show");    
        const modalBody = $('.modal-body');

        modalBody.empty();

        //Form
        var startTime = new Date(Date.parse(sitting.startTime));
        var endTime = new Date(Date.parse(sitting.endTime));
        const form = $('<form>');
        const options = [];

        while (startTime <= endTime) {
            options.push(new Date(startTime));
            startTime.setMinutes(startTime.getMinutes() + 30);
        }

        const startTimeInput = $('<select name="startTime">');
        for (let i = 0; i < options.length; i++) {
            const timeStr = options[i].toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit', hour12: false });
            const timeOption = $(`<option value="${timeStr}">${timeStr}</option>`);
            startTimeInput.append(timeOption);
        }


        const durationInput = $('<input type="number" name="duration">');
        const firstNameInput = $('<input type="text" name="firstName">');
        const lastNameInput = $('<input type="text" name="lastName">');
        const numGuestsInput = $('<input type="number" name="numGuests">');
        const emailInput = $('<input type="email" name="email">');
        const phoneNumberInput = $('<input type="tel" name="phoneNumber">');
        const notesInput = $('<textarea name="notes"></textarea>');
        const submitButton = $('<button color="#ffb03b" type="submit">Submit</button>');

        // Add CSS classes for styling
        form.addClass('reservation-form');
        startTimeInput.addClass('form-select form-control');
        durationInput.addClass('form-input form-control');
        firstNameInput.addClass('form-input form-control');
        lastNameInput.addClass('form-input form-control');
        numGuestsInput.addClass('form-input form-control');
        emailInput.addClass('form-input form-control');
        phoneNumberInput.addClass('form-input form-control');
        notesInput.addClass('form-textarea form-control');
        submitButton.addClass('form-button btn btn-primary');

        // Append form elements to the form
        form.append($('<label class="form-label">First Name:</label>'), firstNameInput);
        form.append($('<label class="form-label">Last Name:</label>'), lastNameInput);
        form.append($('<label class="form-label">Number of Guests:</label>'), numGuestsInput);
        form.append($('<label class="form-label">Starting Time:</label>'), startTimeInput);
        form.append($('<label class="form-label">Duration of Reservation:</label>'), durationInput);
        form.append($('<label class="form-label">Email:</label>'), emailInput);
        form.append($('<label class="form-label">Phone Number:</label>'), phoneNumberInput);
        form.append($('<label class="form-label">Notes:</label>'), notesInput);
        form.append(submitButton);

       

        // Add submit event listener to the form
        form.submit(event => {
            event.preventDefault();
           
            const Reservation = {

                FirstName: firstNameInput.val(),
                LastName: lastNameInput.val(),
                GuestNumber: numGuestsInput.val(),
                // hard-coded date is ignored by server.  it uses sitting date
                StartTime: "2023-05-16T" + startTimeInput.val(),
                Duration: durationInput.val(),
                Email: emailInput.val(),
                PhoneNumber: phoneNumberInput.val(),
                Note: notesInput.val()
            };

            fetch(`/api/sittings/${sitting.id}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(Reservation)
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`Failed to submit booking: ${response.status} ${response.statusText}`);
                    }
                    return response.json();
                })
                .then(data => {
                    // Handle the response data
                    BookingConfirmation(data);
                })
                .catch(error => {
                    // Handle the error
                    alert(error.message);
                });
        });
        // Clear the sittings container and append the form
        $('#sittings-container').empty();

        modalBody.empty().append(form);

        //$(`#reservation-form-container`).append(form)
    }

    function BookingConfirmation(Reservation) {
        $('#sittings-container').empty();
        $(`#reservation-form-container`).empty();

        $("#bookingReservationForm").modal("show");
        const modalBody = $('.modal-body');
        modalBody.empty();

        var startTime = new Date(Reservation.startTime);
        var formattedStartTime = startTime.toLocaleString('en-US', {
            dateStyle: 'medium',
            timeStyle: 'short'
        });

        var reservationInformation = $(`
        <div class="reservation-details">
            <h2>Reservation Details</h2>
            <p><strong>Full Name:</strong> ${Reservation.firstName} ${Reservation.lastName}</p>
            <p><strong>Number of Guests:</strong> ${Reservation.guestNumber}</p>
            <p><strong>Reservation Start Time:</strong> ${formattedStartTime}</p>
            <p><strong>Duration:</strong> ${Reservation.duration}</p>
            <p><strong>Email:</strong> ${Reservation.email}</p>
            <p><strong>Phone Number:</strong> ${Reservation.phoneNumber}</p>
            <p><strong>Additional Notes:</strong> ${Reservation.note}</p>
        </div>      
    `);

        modalBody.append(reservationInformation);

        $('#return-home').click(function () {
            location.reload();
        });
    }
    
})  