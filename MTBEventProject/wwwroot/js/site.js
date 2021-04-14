var checkPasswordsMatch = function() 
{
    
    var pass = document.getElementById('password');
    var passConfirm = document.getElementById('confirm_password');

    if (pass.value == "" || passConfirm.value == "")
    {
        pass.style.borderColor = 'red';
        passConfirm.style.borderColor = 'red';
        document.getElementById("signUpSubmit").disabled = true;
    }
    else if (pass.value == "" && passConfirm.value == "")
    {
        pass.style.borderColor = 'red';
        passConfirm.style.borderColor = 'red';
        document.getElementById("signUpSubmit").disabled = true;
    }
    else if (pass.value == passConfirm.value) 
    {
        pass.style.borderColor = 'green';
        passConfirm.style.borderColor = 'green';
        document.getElementById("signUpSubmit").disabled = false;
    }
    else
    {
        document.getElementById('password').style.borderColor = 'red';
        document.getElementById('confirm_password').style.borderColor = 'red';
        document.getElementById("signUpSubmit").disabled = true;
    }
};
