// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var Id;

function DeleteProduct()
{
    $.ajax({
        type : 'POST',
        dataType : 'html' ,
        url: '/Produto/Delete',
        data:{Id: this.Id},
        success: function(){
            window.location.href = '/Produto';
        }
        
    })
}

function DeleteClient()
    {
        $.ajax({
            type : 'POST',
            dataType : 'html' ,
            url: '/Cliente/Delete',
            data:{Id: this.Id},
            success: function(){
                window.location.href = '/Cliente';
            }            
        })
    }
function showmodal(Id)
{      
    
    this.Id = Id;
    $("#MyModal").modal('show');
}


$(document).ready(function() {   //same as: $(function() { 
    function redirect()
    {
        var elementExists = document.getElementById("SaveRegister");
        if(elementExists !== null )
        {
            window.location.href = 'Login';
        }
    }
    var n = 5;
    var l = document.getElementById("number");
    l.innerHTML = n;
    window.setInterval(function(){
      if(n == 0)
      {
          redirect();
      }
      l.innerHTML = n;
      n--;
    },1000);

    //setTimeout(redirect, 3000);
});



