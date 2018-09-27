
const addUser = () => {
    const student = {
        Age: $('#Age').val(),
        Gender: $('#Gender').val(),
        Salutation: $('#Salutation').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val()
    };
    $.ajax({
        url: '/Students/Create',
        data: JSON.stringify(student),
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        success: function(res) {
            showSuccessDialog('Student added successfully');
        },
        error: function(errormessage) {
            //   loadSkills();
            alert(errormessage.responseText);
        }
    });
    return false;
};

const populateEditForm = (studentId) => {
    $.ajax({
        url: `/Students/GetById/${studentId}`,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        success: function(result) {
            $('#EditId').val(result.id);
            $('#EditAge').val(result.age);
            $('#EditGender').val(result.gender);
            $('#EditSalutation').val(result.salutation);
            $('#EditFirstName').val(result.firstName);
            $('#EditLastName').val(result.lastName);
            $('#editModal').modal('show');
        },
        error: function(errormessage) {
            alert(errormessage.responseText);
        }
    });
};

const updateStudent = () => {
    let student = {
        Id: $('#EditId').val(),
        Age: $('#EditAge').val(),
        Gender: $('#EditGender').val(),
        Salutation: $('#EditSalutation').val(),
        FirstName: $('#EditFirstName').val(),
        LastName: $('#EditLastName').val()
    };
    $.ajax({
        url: `/Students/Edit/${student.Id}`,
        data: JSON.stringify(student),
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        success: function(result) {
            showSuccessDialog('Student updated successfully');
        },
        error: function(errormessage) {
            alert(errormessage.responseText);
        }
    });
};

const showSuccessDialog = (message) => {
    let timerInterval;
    swal({
        title: message,
        type: 'success',
        timer: 5000,
        showCancelButton: true,
        onClose: () => {
            clearInterval(timerInterval);

        }
    }).then(() => {
        window.location.href = "/Students";

    });
}