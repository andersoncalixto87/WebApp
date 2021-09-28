function redirect()
{
    var elementExists = document.getElementById("SaveRegister");
    if(elementExists !== null )
    {
        window.location.href = '@Url.Action("Usuario", "Login")';
    }
}