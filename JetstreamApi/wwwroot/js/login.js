function validateLoginForm(e) {
  e.preventDefault();

  const userName = document.getElementById("userName");
  const password = document.getElementById("password");

  // Entfernen von Leerzeichen am Anfang und Ende der E-Mail
  userName.value = userName.value.trim();

  // Weitere Logik für das Formular, wie das Senden der Daten, falls alle Validierungen erfolgreich sind
  if (validateRequiredField(userName) && validateRequiredField(password)) {
    // Weiterleitung zu Service Aufträge
    window.location.href = "orders.html";
  }
}

// Zeigt Fehlermeldungen an
function showErrorMessage(field, errorMessageId, message) {
  const errorMessageElement = document.getElementById(errorMessageId);
  if (errorMessageElement) {
    errorMessageElement.innerText = message;
    field.classList.remove("border-gray-300", "dark:border-gray-600");
    field.classList.add("border-red-500");
  }
}

// Entfernt Fehlermeldungen
function clearErrorMessage(field, errorMessageId) {
  const errorMessageElement = document.getElementById(errorMessageId);
  if (errorMessageElement) {
    errorMessageElement.innerText = "";
    field.classList.remove("border-red-500");
    field.classList.add("border-gray-300", "dark:border-gray-600");
  }
}

// Überprüft, ob ein Feld ausgefüllt ist
function validateRequiredField(field) {
  return field.value.trim() !== "";
}

document.getElementById("loginForm").addEventListener("submit", function (e) {
  e.preventDefault();

  var rememberMe = document.getElementById("rememberMe").value;

  var userName = document.getElementById("userName").value;
  var password = document.getElementById("password").value;

  fetch("/api/users/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      userName: userName,
      password: password,
    }),
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Login failed");
      }
      return response.json();
    })
    .then((data) => {
      console.log(rememberMe);

      localStorage.setItem("token", data.value.token);
      window.location.href = "/orders.html";
    })
    .catch((error) => {
      console.error("Error:", error);
    });
});
