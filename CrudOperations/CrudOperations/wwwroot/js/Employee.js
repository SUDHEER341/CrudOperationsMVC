$(document).ready(function () {
    getAllEmployees();
});
//$('#addEmp').click(function () {
//    $('#myModal').modal('show');
//})
//Load Employee == start

function getAllEmployees() {
    $.ajax({
        url: '/Employee/GetEmployee',
        type: 'get',
        dataType: 'json',
        success: function (data) {
            var rows = '';

            $.each(data, function (i, employee) {
                rows += '<tr>'
                    + '<td>' + employee.id + '</td>'
                    + '<td>' + employee.name + '</td>'
                    + '<td>' + employee.state + '</td>'
                    + '<td>' + employee.city + '</td>'
                    + '<td>' + employee.salary + '</td>'
                    + '<td>'
                    + '<button class="btn btn-primary " onclick= "Edit('+employee.id+')"> Edit</button> '
                    + '<button class="btn btn-danger " onclick=" Delete('+employee.id+') ">Delete</button>'
                    + '</td>'
                    + '</tr>';
            });
            $('#table_data').html(rows);
            console.log(data);
        }
    })
}
//Load Employee == end




//add Employee == start
function AddEmployee() {
    debugger;
   

    var empData = {
        
        Name: $('#Name').val(),
        State: $('#State').val(),
        City: $('#City').val(),
        Salary : $('#Salary').val()
    }
    console.log(empData);
    $.ajax({
        url: '/Employee/AddEmployee',
        type: 'POST',
        data: empData,
        dataType: 'json',
        success: function () {
            alert("Data saved successfully");
            $('#myForm')[0].reset();
            clodeModal();
            getAllEmployees();

        },
        error: function () {
            alert(500);
        }
    })
}
//add Employee == end


//Edig Employee == start
// 1- get the data to the modal
 function Edit(id) {
    debugger
    $.ajax({
        url: '/Employee/Edit?id= ' + id,
        type: 'get',
        dataType: 'json',
        success: function (response) {
            console.log(response);
            $('#myModal').modal('show');
            $('#EmpId').val(response.id)  ;
            $('#Name').val(response.name)  ;
            $('#State').val(response.state)  ;
            $('#City').val(response.city);
            $('#Salary').val(response.salary);

            $('#updateEmployee').css('display', 'block')
            $('#addEmployee').css('display','none')
            $('.labelId').css('display' , 'block')
            //$('#updateEmployee').show();
            //$('#addEmployee').hide();
        },
        error: function () {
            alert('Data not found');
        }

    })


}
// 2 - update the data to database

function updateEmployee() {
    var empData = {
        Id: $('#EmpId').val(),
        Name: $('#Name').val(),
        State: $('#State').val(),
        City: $('#City').val(),
        Salary: $('#Salary').val()
    }
    debugger

    $.ajax({
        url: '/Employee/UpdateEmployee',
        type: 'Post',
        data: empData,
        dataType: 'json',
        success: function () {
            alert("Data updated successfully");
            $('#myForm')[0].reset();
            clodeModal();
            getAllEmployees();

        },
        error: function () {
            alert("Failed to update data, please try again");
        }
    })
}
//Edit EMployee == end


//Delete Employee
function Delete(id) {
    debugger
    if (confirm('Are you sure you want to delete this employee?'))
    {
        $.ajax({
            url: '/Employee/DeleteEmployee?id=' + id,
            type: 'delete',
            dataType: 'json',
            success: function (response) {
                if (response.success) {
                alert("Record deleted successfully");
                getAllEmployees();
                }

            }


        })

    }
}
//close modal
function clodeModal() {
    $('#myModal').modal('hide');
}

//open modal
function openModal() {
    $('#myModal').modal('show');
    $('.labelId').css('display', 'none')
    $('#updateEmployee').css('display', 'none')
    $('#addEmployee').css('display', 'block')
}
//clear text in form

function clearText() {
    $('#EmpId').val('');
    $('#Name').val('');
    $('#State').val('');
    $('#City').val('');
    $('#Salary').val('');
}