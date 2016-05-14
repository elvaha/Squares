$(function () {

    //Diag for login
    var count = 0;
    $(".user").on("click", function (e) {
        count++;

        alert(count);

        jQuery.get("/Account/Login", function (data) {

          var spliter = data.split('<section id="loginForm">');
          var spliter2 = spliter[1].split("</section>");
        
          if (count == 2) { $(".wrapper").removeClass("userMove"); count = 0;}
          else {
              $(".wrapper").append("<span class='userMove'>" + spliter2[0] + "</span>");
          }
         })
        e.preventDefault();
    })

});