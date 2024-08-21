// Initialize the variables
const address = "https://localhost:7047/";
const userAPI = "api/math/";
var income = 0;
var housing = 0;
var food = 0;
var transportation = 0;
var entertainment = 0;
var utilities = 0;
var insurance = 0;
var other = 0;
var saving = 0;
var debtRepayment = 0;
var expenses = [];

var form = document.querySelector("#budget-form");

// Add event listener to the form to get the values of the input fields when the form
// is submitted and send them to the server to calculate the sum of the expenses
form.addEventListener("submit", function (e) {
    e.preventDefault();
    income = document.querySelector("#monthly-income").value;

    housing = document.querySelector("#housing").value;
    food = document.querySelector("#food").value;
    transportation = document.querySelector("#transportation").value;
    entertainment = document.querySelector("#entertainment").value;
    utilities = document.querySelector("#utilities").value;
    insurance = document.querySelector("#insurance").value;
    other = document.querySelector("#other").value;
    savings = document.querySelector("#savings").value;
    debtRepayment = document.querySelector("#debt-repayment").value;

    expenses = [housing, food, transportation, entertainment, utilities, insurance, other, saving, debtRepayment];

    for (var i = 0; i < expenses.length; i++) {
        if (expenses[i] == "") {
            expenses[i] = 0;
        }
    }

    fetch(address + userAPI + "SumOf", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(expenses),
    })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            alert(data);
        })
        .catch((error) => {
            console.error("Error:", error);
        });

    });