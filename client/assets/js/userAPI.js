// If I had access to JWT (JSON Web Token) I would use it to authenticate the user, but I don't, so I'll just make a client side token.

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

document.addEventListener("DOMContentLoaded", (event) => {
  user = getToken();
  if (user) {
    alert(user.username);
  }
});

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
      //   let test = JSON.parse(data);
      //   console.log(test);
      //   console.log(data["item1"]);
      //   console.log(data.item2);
      if (data.item1 == true) {
        // Login

        const username = data.item2;
        const isUserValid = data.item1;
        createToken(username, isUserValid);
      } else {
        // Email or password was incorrect
      }
    })
    .catch((error) => {
      console.error("Error: ", error);
    });
}

function register() {
  return fetch("/api/register").then((res) => res.json());
}

function createToken(username, isUserValid) {
  const tokenData = {
    username: username,
    isUserValid: isUserValid,
  };
  const token = JSON.stringify(tokenData);
  localStorage.setItem("loginToken", token);
  return token;
}

// TODO: Call this on pageload
function getToken() {
  const token = localStorage.getItem("loginToken");
  if (token) {
    const tokenData = JSON.parse(token);
    return tokenData;
  } else {
    return null;
  }

  // const tokenData = getToken();
  // if (tokenData) { console.log(tokenData.username); console.log(tokenData.isAdmin); }
  // else { console.log("No token found"); }
}
