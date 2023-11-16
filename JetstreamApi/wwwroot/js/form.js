function showErrorMessage(field, errorMessageId, message) {
  document.getElementById(errorMessageId).innerText = message;
  field.classList.remove("border-gray-300", "dark:border-gray-600");
  field.classList.add("border-red-500");
}

function clearErrorMessage(field, errorMessageId) {
  document.getElementById(errorMessageId).innerText = "";
  field.classList.remove("border-red-500");
  field.classList.add("border-gray-300", "dark:border-gray-600");
}

function validateRequiredField(field) {
  if (field.value === "") {
    field.classList.add("error");
    return false;
  } else {
    field.classList.remove("error");
    return true;
  }
}

function validateNameFormat(field) {
  const namePattern = /^[a-zA-ZäöüÄÖÜß]+$/;
  if (!namePattern.test(field.value)) {
    return false;
  }
  return true;
}

function validateEmailFormat(field) {
  const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  if (!emailPattern.test(field.value)) {
    return false;
  }
  return true;
}

function validatePhoneNumber(field) {
  const phonePattern =
    /(\b(0041|0)|\B\+41)(\s?\(0\))?(\s)?[1-9]{2}(\s)?[0-9]{3}(\s)?[0-9]{2}(\s)?[0-9]{2}\b/;
  if (!phonePattern.test(field.value)) {
    return false;
  }
  return true;
}

function formatDate(dateString) {
  const parts = dateString.split("/");
  const newDate = new Date(parts[2], parts[1] - 1, parts[0]);
  const now = new Date();
  if (!isNaN(newDate)) {
    return (
      newDate.getFullYear() +
      "-" +
      String(newDate.getMonth() + 1).padStart(2, "0") +
      "-" +
      String(newDate.getDate()).padStart(2, "0") +
      "T" +
      String(now.getHours()).padStart(2, "0") +
      ":" +
      String(now.getMinutes()).padStart(2, "0") +
      ":" +
      String(now.getSeconds()).padStart(2, "0")
    );
  } else {
    return "";
  }
}

function validateForm(e) {
  e.preventDefault();
  const firstName = document.getElementById("firstname");
  const lastName = document.getElementById("lastname");
  const email = document.getElementById("email");
  const phone = document.getElementById("phone");
  const priority = document.querySelector(
    'input[name="list-radio"]:checked'
  ).value;
  const createDate = formatDate(document.getElementById("startDate").value);
  const pickupDate = formatDate(document.getElementById("endDate").value);
  const serviceId = parseInt(document.getElementById("serviceDropdown").value);
  const priceString = document
    .getElementById("total")
    .value.replace("CHF ", "")
    .replace(".-", "");
  const price = parseFloat(priceString);
  const statusId = 1;
  const comment = "";

  // Formularfelder trimmen, um Leerzeichen zu entfernen
  firstName.value = firstName.value.trim();
  lastName.value = lastName.value.trim();
  email.value = email.value.trim();
  phone.value = phone.value.trim();

  // Validation
  let isValid = true;

  if (!validateRequiredField(firstName) || !validateNameFormat(firstName)) {
    isValid = false;
    showErrorMessage(
      firstName,
      "errorMessageFirstName",
      "Bitte eine gültige Vorname eingeben"
    );
  } else {
    clearErrorMessage(firstName, "errorMessageFirstName");
  }

  if (!validateRequiredField(lastName) || !validateNameFormat(lastName)) {
    isValid = false;
    showErrorMessage(
      lastName,
      "errorMessageLastName",
      "Bitte eine gültige Nachname eingeben."
    );
  } else {
    clearErrorMessage(lastName, "errorMessageLastName");
  }

  if (!validateRequiredField(email) || !validateEmailFormat(email)) {
    isValid = false;
    showErrorMessage(
      email,
      "errorMessageEmail",
      "Bitte eine gültige E-Mail eingeben."
    );
  } else {
    clearErrorMessage(email, "errorMessageEmail");
  }

  if (!validateRequiredField(phone) || !validatePhoneNumber(phone)) {
    isValid = false;
    showErrorMessage(
      phone,
      "errorMessagePhone",
      "Bitte eine gültige Telefonnummer eingeben"
    );
  } else {
    clearErrorMessage(phone, "errorMessagePhone");
  }

  // Formular abschicken bei erfolgreicher Validierung
  if (isValid) {
    // Log the values for debugging purposes
    console.log(
      "firstname: " + firstName.value,
      "lastName: " + lastName.value,
      "email: " + email.value,
      "phone:" + phone.value,
      "priority:" + priority,
      "serviceId:" + serviceId,
      "createDate:" + createDate,
      "pickupDate:" + pickupDate,
      "price:" + price,
      "statusId:" + statusId,
      "comment:" + comment
    );
    // Create the DTO
    const ServiceRequestCreateDTO = {
      Firstname: firstName.value,
      Lastname: lastName.value,
      Email: email.value,
      Phone: phone.value,
      PriorityId: priority,
      CreateDate: createDate,
      PickupDate: pickupDate,
      ServiceId: serviceId,
      Price: price,
      StatusId: statusId,
      Comment: comment,
    };

    // Post the data
    postData(ServiceRequestCreateDTO);
  }
}
// Funktionen für Validierungen und Formularverarbeitung
function validateRequiredField(field) {
  if (field.value === "") {
    field.classList.add("error");
    return false;
  } else {
    field.classList.remove("error");
    return true;
  }
}

function calculateTotal() {
  let serviceCost = 0;
  let priorityCost = 0;

  const serviceOption = document.querySelector("select").value;
  if (serviceOption === "1") {
    serviceCost = 49;
  } else if (serviceOption === "2") {
    serviceCost = 69;
  } else if (serviceOption === "3") {
    serviceCost = 99;
  } else if (serviceOption === "4") {
    serviceCost = 39;
  } else if (serviceOption === "5") {
    serviceCost = 25;
  } else if (serviceOption === "6") {
    serviceCost = 18;
  }
  // ... (weitere Optionen)

  const priority = document.querySelector(
    'input[name="list-radio"]:checked'
  ).value;
  if (priority === "2") {
    priorityCost = 5;
  } else if (priority === "3") {
    priorityCost = 10;
  }

  const total = serviceCost + priorityCost;
  document.getElementById("total").value = `CHF ${total}.-`;

  const totalValueForBackend = parseFloat(total.toString());
  const dataToSend = {
    price: totalValueForBackend,
  };
}

function postData(dto) {
  fetch("/api/ServiceRequests", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(dto),
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok.");
      }
      return response.json();
    })
    .then((data) => {
      // Hier können Sie den Erfolg verarbeiten, z.B. Weiterleitung zu einer Bestätigungsseite
      window.location.href = "formconfirm.html";
    })
    .catch((error) => {
      // Hier können Sie Fehler verarbeiten, z.B. Anzeigen einer Fehlermeldung für den Benutzer
      console.error(
        "There has been a problem with your fetch operation:",
        error
      );
      window.location.href = "formerror.html";
    });
}

const params = new URLSearchParams(window.location.search);
const dropdownValue = params.get("service");

if (dropdownValue) {
  const selectElement = document.querySelector("select");
  selectElement.value = dropdownValue;
}

function setEstimatedPickupDate(priority, startDate) {
  let start = new Date(startDate);
  let daysToAdd = 0;

  if (priority === "1") {
    daysToAdd = 12;
  } else if (priority === "2") {
    daysToAdd = 7;
  } else if (priority === "3") {
    daysToAdd = 5;
  }

  const newDate = new Date(start);
  newDate.setDate(start.getDate() + daysToAdd);

  const formattedDate = `${String(newDate.getDate()).padStart(2, "0")}/${String(
    newDate.getMonth() + 1
  ).padStart(2, "0")}/${newDate.getFullYear()}`;

  document.getElementById("endDate").value = formattedDate;
}

window.onload = function () {
  document
    .getElementById("submitForm")
    .addEventListener("submit", validateForm);

  const startDateInput = document.getElementById("startDate");
  const today = new Date();
  const formattedToday = `${String(today.getDate()).padStart(2, "0")}/${String(
    today.getMonth() + 1
  ).padStart(2, "0")}/${today.getFullYear()}`;

  startDateInput.value = formattedToday;
  setEstimatedPickupDate("Tief", today);

  document.querySelectorAll('input[name="list-radio"]').forEach((radio) => {
    radio.addEventListener("change", function () {
      console.log("radio changed to " + this.value);
      const startDateValue = startDateInput.value.split("/");
      const startDate = new Date(
        `${startDateValue[2]}-${startDateValue[1]}-${startDateValue[0]}`
      );
      setEstimatedPickupDate(this.value, startDate);
      calculateTotal();
    });
  });

  startDateInput.addEventListener("change", function () {
    const selectedDateValue = this.value.split("/");
    const selectedDate = new Date(
      `${selectedDateValue[2]}-${selectedDateValue[1]}-${selectedDateValue[0]}`
    );
    const priority = document.querySelector(
      'input[name="list-radio"]:checked'
    ).value;
    setEstimatedPickupDate(priority, selectedDate);
  });

  // Event-Listener für Änderungen an der Service-Dropdown-Auswahl
  document.querySelector("select").addEventListener("change", function () {
    calculateTotal();
  });

  // Startwert für den Gesamtbetrag setzen
  calculateTotal();
};

let lastKnownStartDate = "";

setInterval(() => {
  const startDateInput = document.getElementById("startDate");
  const currentStartDate = startDateInput.value;

  if (currentStartDate !== lastKnownStartDate) {
    lastKnownStartDate = currentStartDate;

    const startDateValue = currentStartDate.split("/");
    const startDate = new Date(
      `${startDateValue[2]}-${startDateValue[1]}-${startDateValue[0]}`
    );
    const priority = document.querySelector(
      'input[name="list-radio"]:checked'
    ).value;

    setEstimatedPickupDate(priority, startDate);
  }
}, 500); // alle 500 Millisekunden
