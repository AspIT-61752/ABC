const address = "https://localhost:7047/";
const userAPI = "api/math/";


var form = document.querySelector("#budget");

form.addEventListener("submit", function (e) {
    e.preventDefault();
    income = document.querySelector("#monthly-income").value;
    alert(income);
    });