// Initialize the variables
const address = "http://10.203.16.58:7777/";
const mathAPI = "api/math/";
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
var total = 0;
var rest = 0;

var form = document.querySelector("#budget-form");
var totalText = document.querySelector("#total");
var restText = document.querySelector("#remaining");

var body = null;

var parsedIncome = null;
var parsedReceivedTotal = null;

// Add event listener to the form to get the values of the input fields when the form
// is submitted and send them to the server to calculate the sum of the expenses
form.addEventListener("submit", function (e) {
    // Reset the total sum of the expenses
    total = 0;
    rest = 0;

    // Prevent the form from submitting and refreshing the page
    e.preventDefault();

    // Get the values of the input fields and store them in the variables
    income = document.querySelector("#monthly-income").value;
    income = parseFloat(income);

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

    // Check if the input fields are empty and set the value to 0 if they are
    for (var i = 0; i < expenses.length; i++) {
        if (expenses[i] == "") {
            expenses[i] = 0;
        }
    }

    // Calculate the total sum of the expenses
    calculateTotal();
    });

    // Fetch the data from the server and calculate the total sum of the expenses
     function calculateTotal() {
     // Send the values of the input fields to the server to calculate the sum of the expenses
    fetch(address + mathAPI + "SumOf", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(expenses),
    })
        .then((response) => response.json())
        .then((data) => {
            console.log("Total: $" + data);
            total = data;
            // Display the total sum of the expenses
            totalText.textContent = "$" + total;
            console.log("Total: $" + total);
            console.log("Income: $" + income);


                      // Send the values of the input fields to the server to calculate the remaining amount
                      fetch(address + mathAPI + `Subtract?a=${income}&b=${total}`, {
                        method: "POST",
                        body: {},
                    })
                        .then((response) => response.json())
                        .then((data) => {
                            console.log(data);
                            rest = data;
                            // Display the remaining amount
                            restText.textContent = "$" + rest;
                        })
                        .catch((error) => {
                            console.error("Error:", error);
                        });
                
        })
        .catch((error) => {
            console.error("Error:", error);
        });
    }




        

    




    


