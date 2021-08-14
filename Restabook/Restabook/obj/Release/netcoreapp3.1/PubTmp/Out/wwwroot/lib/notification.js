var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();


connection.start().then(function () {
    console.log("User connected");
}).catch(function (err) {
    return console.error(err);
});


$(document).ready(function () {

    connection.on("OrderCreated", function (user, date) {

       


        var encodedMsg1 = ` <a class="dropdown-item d-flex align-items-center" href="#">
                                    <div class="mr-3">
                                        <div class="icon-circle bg-primary">
                                            <i class="fas fa-file-alt text-white"></i>
                                        </div>
                                    </div>
                                    <div>
                                        <div class="small text-gray-500">${date}</div>
                                        <span class="font-weight-bold">${user} has order</span>
                                    </div>
                                </a>`
        $("#notification").append(encodedMsg1)


        
    });


    connection.on("MessageSent", function (user, message, date) {

       


        var encodedMsg2 = `   <a class="dropdown-item d-flex align-items-center" href="#">
                                    <div class="dropdown-list-image mr-3">
                                       
                                        <div class="status-indicator bg-success"></div>
                                    </div>
                                    <div class="font-weight-bold">
                                        <div class="text-truncate">
                                            ${message}
                                        </div>
                                        <div class="small text-gray-500">${user} · ${date}</div>
                                    </div>
                                </a>`
        $("#messagefromuser").append(encodedMsg2)
    });
})
