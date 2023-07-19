$(() => {
    let floorplan = $('<div style="width: 1000px; height: 800px; background-color: #ebebeb; border: 1px solid #ccc; position: relative;"></div>');
    loadFloorPlan();
    initDragAndDropElements();

    function loadFloorPlan() {
        // Set up the outside, dining, and balcony areas
        let outsideArea = $('<div class="outside-area" style="background-color: #f2f2f2; height: 30%; width: 100%; position: absolute; top: 0; left: 0;"></div>');
        let diningArea = $('<div class="dining-area" style="background-color: #333; height: 60%; width: 100%; position: absolute; top: 30%; left: 0;"></div>');
        let balconyArea = $('<div class="balcony-area" style="background-color: #737270; height: 15%; width: 100%; position: absolute; bottom: 0; left: 0;"></div>');

        // Add labels for the areas
        let outsideLabel = $('<div class="area-label" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%); color: rgba(0, 0, 0, 0.5); font-size: 24px; font-weight: bold;">Outside</div>');
        let diningLabel = $('<div class="area-label" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%); color: rgba(255, 255, 255, 0.5); font-size: 24px; font-weight: bold;">Dining</div>');
        let balconyLabel = $('<div class="area-label" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%); color: rgba(0, 0, 0, 0.5); font-size: 24px; font-weight: bold;">Balcony</div>');

        // Append the areas and labels to the floorplan
        outsideArea.append(outsideLabel);
        diningArea.append(diningLabel);
        balconyArea.append(balconyLabel);
        floorplan.append(outsideArea);
        floorplan.append(diningArea);
        floorplan.append(balconyArea);

        // Append the floorplan div to the container
        $('#reservation-tables-container').append(floorplan);
    }


    function initDragAndDropElements() {
        //reservations (draggable)
        fetch(`/api/ReservationTables`)
            .then(r => r.json())
            .then(reservations => {
                let header = $('<h4>Reservations:</h4>');
                $('#reservation-container').append(header);
                for (let r of reservations) {
                   
                    let reservation = $(`
                        <div class="reservation" id="${r.id}">
                            <span>${r.email}</span>
                        </div>
                    `);
                    reservation.css({
                        'border': '1px solid blue',
                        'padding': '5px',
                        'margin': '5px',
                        'cursor': 'pointer',
                        'width': '200px',
                        'background-color': 'white',
                        'border-radius': '5px',
                        'text-align': 'center'
                    });
                    reservation.find('span').css({
                        'color': 'blue'
                    });
                    $('#reservation-container').append(reservation);
                    reservation.click(function () {
                        
                        // Fetch reservation details when clicked
                        fetch(`/api/ReservationTables/${r.id}`)
                            .then(response => response.json())
                            .then(reservationDetails => {
                               
                                // Populate modal with reservation details
                                $('#exampleModalLabel').text('Reservation Details');
                                let modalBody = $('.modal-body');
                                modalBody.empty();
                                //modalBody.append(`<p>Sitting:</p>`)
                                modalBody.append(`<p>Full Name: ${reservationDetails.firstName} ${reservationDetails.lastName}</p>`);
                                modalBody.append(`<p>Email: ${reservationDetails.email}</p>`);
                                modalBody.append(`<p>Phone Number: ${reservationDetails.phoneNumber}</p>`);
                                modalBody.append(`<p>Number of Guests: ${reservationDetails.guestNumber}</p>`);
                                modalBody.append(`<p>Special Notes: ${reservationDetails.note}</p>`);
                                modalBody.append(`<p>Start time ${reservationDetails.startTime}</p>`)
                                modalBody.append(`<p>Table(s): ${reservationDetails.reservationTables.map(table => table.restaurantTable.name).join(", ")}</p>`)
                                $('#exampleModal').modal('show');
                            });
                    });


                    reservation.draggable({
                        snap: true,
                        snapMode: 'inner',
                        stop: function (event, ui) {
                            reservation.css('left', 0 + "px")
                            reservation.css('top', 0 + "px")
                            alert(`Reservation ${r.email} was assigned a table.`)
                        }
                    });
                    //$('.reservation').mouseover(function () {
                        
                    //    // Retrieve information from the hovered div
                    //    let reservationId = $(this).attr('id');
                    //    let email = $(this).find('span').text();
                    //});
                }
            });

        //tables
        fetch("/api/ReservationTables/tables")
            .then(s => s.json())
            .then(tables => {
                for (let table of tables) {
                    for (let t of table.tables) {
                        let tableDivs;

                        if (t.posX == undefined && t.posY == undefined) {
                            tableDivs = $(`
                                <div class="table" id="${t.id}">
                                    <div class="table-content">
                                        <span class="table-name">Table: ${t.name}</span>
                                    </div>
                                </div>
                            `);
                            tableDivs.css({
                                'width': '100px',
                                'height': '50px',
                                'background-color': '#f2f2f2',
                                'position': 'absolute',
                                'border': '1px solid #ccc',
                                'border-radius': '5px',
                                'display': 'flex',
                                'align-items': 'center',
                                'justify-content': 'center',
                            });

                            tableDivs.find('.table-content').css({
                                'padding': '5px',
                            });

                            tableDivs.find('.table-name').css({
                                'color': '#333',
                                'font-weight': 'bold',
                            });

                        }
                        else {
                            tableDivs = $(`
                                <div class="table" id="${t.id}">
                                    <div class="table-content">
                                        <span class="table-name">Table: ${t.name}</span>
                                    </div>
                                </div>
                            `);
                            tableDivs.css({
                                'width': '100px',
                                'height': '50px',
                                'background-color': '#f2f2f2',
                                'position': 'absolute',
                                'border': '1px solid #ccc',
                                'border-radius': '5px',
                                'display': 'flex',
                                'align-items': 'center',
                                'justify-content': 'center',
                            });

                            tableDivs.find('.table-content').css({
                                'padding': '5px',
                            });

                            tableDivs.find('.table-name').css({
                                'color': '#333',
                                'font-weight': 'bold',
                            });
                            tableDivs.css('left', t.posX + "px")
                            tableDivs.css('top', t.posY + "px")
                        }
                         
                        floorplan.append(tableDivs);
                        tableDivs.draggable({
                            containment: 'parent',
                            snap: true,
                            stop: function (event, ui) {
                                let position = ui.position
                                let tableId = $(this).attr('id');

                                const reservationTable = {
                                    id: tableId,
                                    posX: position.left,
                                    posY: position.top
                                };
                                fetch("/api/ReservationTables/UpdateTablePosition", {
                                    method: 'POST',
                                    headers: {
                                        'Content-Type': 'application/json'
                                    },
                                    body: JSON.stringify(reservationTable)
                                })
                            }
                        })


                        tableDivs.droppable({
                            accept: '.reservation',
                            activate: function (event, ui) {
                                $(this).addClass('highlight');
                            },
                            deactivate: function (event, ui) {
                                $(this).removeClass('highlight');
                            },
                            drop: function (event, ui) {
                                let tableId = $(this).attr('id');
                                let reservationId = ui.draggable.attr('id');
                                handleReservationDrop(reservationId, tableId);
                                
                            }
                        }).hover(
                            function () {
                                $(this).addClass('highlight');
                            },
                            function () {
                                $(this).removeClass('highlight');
                            }
                        ).css('border-color', '#ccc');
                    }
                }
            })
    }

    function handleReservationDrop(reservationId, tableId) {

        let tableVM = {
            TableId: tableId,
            ReservationId: reservationId

        };
        fetch("/api/ReservationTables/UpdateReservationTable", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(tableVM)
        })

    }


    $("#createTable").click(function () {
        
      
        debugger;
        let tableDiv = $('<div class="table" style="width: 100px; height: 50px; background-color: #fff; position: absolute;"><span class="table-name">Extra Table</span></div>');
     
        tableDiv.css({
            'width': '100px',
            'height': '50px',
            'background-color': '#f2f2f2',
            'position': 'absolute',
            'border': '1px solid #ccc',
            'border-radius': '5px',
            'display': 'flex',
            'align-items': 'center',
            'justify-content': 'center',
        });
        tableDiv.draggable({
            snap: true
        });
        floorplan.append(tableDiv);
    })
})




