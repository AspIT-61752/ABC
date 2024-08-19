const address = "https://localhost:7047/";
const userAPI = "api/User/";
const isUserValid = "IsUserValid?";

const requestGet = {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
  },
};

const requestPost = {
  method: "POST",
  headers: {
    "Content-Type": "application/json",
  },
};

const requestPut = {
  method: "PUT",
  headers: {
    "Content-Type": "application/json",
  },
};

const requestDelete = {
  method: "DELETE",
  headers: {
    "Content-Type": "application/json",
  },
};

// const URL = "http://localhost:3000/api/user";

let user = null;
let username = document.getElementById("username");

function getUser() {
  return fetch("/api/user").then((res) => res.json());
}

function getPosts() {
  return fetch("/api/posts").then((res) => res.json());
}

function signIn() {
  //   return fetch("/api/signin").then((res) => res.json());

  let email = document.querySelector("#floatingInputEmail");
  let password = document.querySelector("#floatingPassword");

  let url =
    address +
    userAPI +
    isUserValid +
    "Email=" +
    email.value +
    "&Password=" +
    password.value;

  //   console.log(email.value);
  //   console.log(password.value);
  //   console.log(url);

  // Call API and get the user

  fetch(url, requestGet)
    .then((res) => res.json())
    .then((data) => {
      console.log("Success: ", data);
    })
    .catch((error) => {
      console.error("Error: ", error);
    });
}

function register() {
  return fetch("/api/register").then((res) => res.json());
}
