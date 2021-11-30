/**
*This function validate booking form,
*and it has multiple variables to pass data to from HTML 
*and valide against checking criteria
*@return a warning message when validation does not pass, or 
*a message of enquiry successfully submitted when validation
*passes
*/
function contactFormValidation()
{
    var firstName = document.forms["bookingform"]["firstname"].value;
    var fl_fn = firstName.charAt(0);
    var slice_fn = firstName.slice(1);
    var middleName = document.forms["bookingform"]["middlename"].value;
    var lastName = document.forms["bookingform"]["lastname"].value;
    var fl_ln = lastName.charAt(0);
    var slice_ln = lastName.slice(1);
    // var phoneAreaCode = document.getElementById("phoneareacode");
    var phoneAreaCode = document.forms["bookingform"]["phoneareacode"];
    // var phoneAreaCodeValue = phoneAreaCode.options[phoneAreaCode.selectedIndex].value;
    var phoneNumber = document.forms["bookingform"]["phonenumber"].value;
    var email = document.forms["bookingform"]["email"].value;
    var message = document.forms["bookingform"]["contactmessage"].value;
    
    if(firstName == "")
    {
        alert("First Name: Please enter your First Name.");
        return false;
    }
    else if (firstName !="")
    {
        if(fl_fn != fl_fn.toUpperCase() && slice_fn == slice_fn.toLowerCase())
        {
            alert("First Name: Please ensure first letter is capital and the rest are lower case.");
            return false;

        }
        else if (fl_fn == fl_fn.toUpperCase() && slice_fn != slice_fn.toLowerCase())
        {
            alert("First Name: Please ensure first letter is capital and the rest are lower case.");
            return false;

        }
        else if (fl_fn != fl_fn.toUpperCase() && slice_fn != slice_fn.toLowerCase())
        {
            alert("First Name: Please ensure first letter is capital and the rest are lower case.");
            return false;
        }
    }
    if(lastName == "")
    {
        alert("Last Name: Please enter your Last Name.");
        return false;
    }
    else if (lastName !="")
    {
        if(fl_ln != fl_ln.toUpperCase() && slice_ln == slice_ln.toLowerCase())
        {
            alert("Last Name: Please ensure first letter is capital and the rest are lower case.");
            return false;

        }
        else if (fl_ln == fl_ln.toUpperCase() && slice_ln != slice_ln.toLowerCase())
        {
            alert("Last Name: Please ensure first letter is capital and the rest are lower case.");
            return false;

        }
        else if (fl_ln != fl_ln.toUpperCase() && slice_ln != slice_ln.toLowerCase())
        {
            alert("Last Name: Please ensure first letter is capital and the rest are lower case.");
            return false;
        }
    }
    if(!phoneNumber && !email)
    {
        alert("Phone Number / Email: Please ensure at lease one is entered.");
        return false;
    }
    else if(phoneNumber !="")
    {
        if(phoneNumber != parseInt(phoneNumber))
        {
            alert("Phone Number: Please ensure ONLY DIGITS after Area Code.");
            return false;
        }
        else if(phoneNumber.length != 8 )
        {
            alert("Phone Numebr: Please ensure 8 digits after Area Code.");
            return false;
        }
        else if(phoneAreaCode.selectedIndex == 0)
        {
            alert("Area Code: Please ensure a valid area code is selected.");
            return false;
        }
    }  
    if(email.indexOf("@") < 1)
    {
        alert("Email: Please ensure @ is included.");
        return false;
    }
    if(!message)
    {
        alert("Message: Please ensure message box is completed.");
         return false;
    }
       

    alert("Thank you for your enquiry. We will endeavour to get back to you within the next 8 hours.");

}
