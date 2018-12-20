 function GetEmployees() {

        var id = document.getElementById('txtIdEmployee').value;

        $.ajax({
            url: '/GetEmployees/GetAllEmployees',
               type: 'GET',
               dataType: 'json',
               cache: false,
               data: { 'id': id },
            success: function (results) {
                BuildGrid(results);
               },
               error: function () {
                alert('Error occured');
               }
       });
    }

    function BuildGrid(results) {

        var headString = "<thead><th>Id</th><th>Name</th><th>Hourly Salary</th><th>Monthly Salary</th><th>Calculated Anual Salary</th></thead><tbody>";

        var acum = headString;
        var sw = 0;
        var cssClass;
        for (var i = 0; i < results.length; i++) {
            
            if (sw == 0) {
                cssClass = "RowImpar";
                sw = "1";
            }
            else {
                cssClass = "RowPar";
                sw = "0";
            }

            acum += "<tr class='" + cssClass + "'>" +
            "<th>" + results[i].Id + "</th>" +
            "<th>" + results[i].Name + "</th>" +
            "<th>" + results[i].HourlySalary + "</th>" +
            "<th>" + results[i].MonthlySalary + "</th>" +
            "<th>" + results[i].CalculatedAnualSalary + "</th>" +         
            "</tr>";   
        }
        var foodString = "</tbody>";
        acum += foodString;
        document.getElementById('CustomGrid').innerHTML = acum;      
    }

    function OnlyNumbers(e) {
        var key = window.event ? e.which : e.keyCode;
        if (key < 48 || key > 57) {
            e.preventDefault();
        }
    }