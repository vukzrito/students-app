const isAddStudentValid = () => {
    var isValid = true;
    if ($('#FirstName').val().trim() === '') {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#FirstName').css('border-color', 'lightgrey');
    }
    if ($('#Age').val().trim() === '' || $('#Age').val() === 0) {
        $('#Age').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Age').css('border-color', 'lightgrey');
    }
    if ($('#LastName').val().trim() === '') {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#Gender').val().trim() === '') {
        $('#Gender').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Gender').css('border-color', 'lightgrey');
    }
    return isValid;
}