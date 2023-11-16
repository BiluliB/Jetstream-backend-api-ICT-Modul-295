document.addEventListener("DOMContentLoaded", () => {
  loadServiceRequests();
});

function loadServiceRequests() {
  fetch("/api/ServiceRequests")
    .then((response) => {
      if (!response.ok) {
        throw new Error("Netzwerkantwort war nicht ok");
      }
      return response.json();
    })
    .then((data) => {
      populateTableWithServiceRequests(data);
    })
    .catch((error) => {
      console.error("Fehler beim Laden der Serviceanfragen:", error);
    });
}

function getStatusNameById(statusCode) {
  const statusNames = {
    1: "offen",
    2: "in Arbeit",
    3: "abgeschlossen",
    4: "storniert",
  };

  return statusNames[statusCode] || "Unbekannter Status";
}

function getStatusIdByName(statusName) {
  const statusIds = {
    offen: 1,
    "in Arbeit": 2,
    abgeschlossen: 3,
    storniert: 4,
  };

  return statusIds[statusName] || null; // Rückgabe von null, wenn der Name nicht gefunden wird
}

function getPriorityNameById(id) {
  const priorityNames = {
    1: "tief",
    2: "standard",
    3: "hoch",
  };
  return priorityNames[id] || "Unbekannte Priorität";
}

function getPriorityIdByName(name) {
  const priorityIds = {
    tief: 1,
    standard: 2,
    hoch: 3,
  };
  return priorityIds[name] || null;
}

function getServiceNameById(id) {
  const serviceNames = {
    1: "kleiner Service",
    2: "großer Service",
    3: "Rennskiservice",
    4: "Bindung montieren und einstellen",
    5: "Fell zuschneiden",
    6: "Heißwachsen",
  };
  return serviceNames[id] || "Unbekannter Service";
}

function getServiceIdByName(name) {
  const serviceIds = {
    "kleiner Service": 1,
    "großer Service": 2,
    Rennskiservice: 3,
    "Bindung montieren und einstellen": 4,
    "Fell zuschneiden": 5,
    Heißwachsen: 6,
  };
  return serviceIds[name] || null;
}

function formatISODateToLocalDate(isoDate) {
  if (!isoDate) return "";
  const date = new Date(isoDate);
  return date.toLocaleDateString("de-CH");
}

function formatDate(dateString) {
  const parts = dateString.split(".");
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

function populateTableWithServiceRequests(serviceRequests) {
  const tableBody = document.querySelector("#serviceRequestsTable tbody");
  tableBody.innerHTML = "";

  serviceRequests.forEach((request, index) => {
    const row = document.createElement("tr");
    row.setAttribute("id", `row-${request.id}`);
    row.style.backgroundColor = index % 2 === 0 ? "#f3f3f3" : "#ffffff";
    const formattedCreateDate = formatISODateToLocalDate(request.createDate);
    const formattedPickupDate = formatISODateToLocalDate(request.pickupDate);

    row.innerHTML = `
      <td class="px-6 py-1">${request.id}</td>
      <td class="px-6 py-1 editable">${request.lastname}</td>
      <td class="px-6 py-1 editable">${request.firstname}</td>
      <td class="px-6 py-1 editable">${request.email}</td>
      <td class="px-6 py-1 editable">${request.phone}</td>
      <td class="px-6 py-1 editable">${request.price.toFixed(2)}</td>
      <td class="px-6 py-1 editable">${formattedCreateDate}</td>
      <td class="px-6 py-1 editable whitespace-nowrap w-auto">${formattedPickupDate}</td>
      <td class="px-6 py-1 editable">${getServiceNameById(
        request.serviceId
      )}</td>
      <td class="px-6 py-1 editable">${getPriorityNameById(
        request.priorityId
      )}</td>
      <td class="px-6 py-1 editable">${getStatusNameById(request.statusId)}</td>
      <td class="px-6 py-1 editable">${request.comment || ""}</td>
      <td class="px-6 py-1 text-right action-cell">
        <button onclick="editServiceRequest(${
          request.id
        })" class="edit-button text-blue-500 hover:text-blue-700 p-2">
          <img src="./assets/ico/Edit_duotone_line.svg" alt="Edit" class="w-6 h-6" />
        </button>
        
        <button onclick="saveServiceRequest(${
          request.id
        })" class="save-button text-green-500 hover:text-green-700 p-2 hidden">
          <img src="./assets/ico/Save_duotone.svg" alt="Save" class="w-6 h-6" />
        </button>
        <button onclick="deleteServiceRequest(${
          request.id
        })" class="delete-button text-red-500 hover:text-red-700 p-2">
          <img src="./assets/ico/Trash_duotone_line.svg" alt="Delete" class="w-6 h-6" />
        </button>
      </td>
    `;
    tableBody.appendChild(row);
  });
}

function editServiceRequest(id) {
  const row = document.querySelector(`#row-${id}`);
  if (!row) return;

  const cells = row.querySelectorAll(".editable");
  cells.forEach((cell, index) => {
    let html = "";
    const currentValue = cell.innerText.trim();

    if (index === 8) {
      // Angenommen, dies ist die Spalte für 'priority'
      html = `<select class="text-sm p-1 w-full max-w-xs">
                <option value="1" ${
                  currentValue === "tief" ? "selected" : ""
                }>tief</option>
                <option value="2" ${
                  currentValue === "standard" ? "selected" : ""
                }>standard</option>
                <option value="3" ${
                  currentValue === "hoch" ? "selected" : ""
                }>hoch</option>
              </select>`;
    } else if (index === 7) {
      // Angenommen, dies ist die Spalte für 'service'
      html = `<select class="text-sm p-1 w-full max-w-xs">
                <option value="1" ${
                  currentValue === "kleiner Service" ? "selected" : ""
                }>kleiner Service</option>
                <option value="2" ${
                  currentValue === "großer Service" ? "selected" : ""
                }>großer Service</option>
                <option value="3" ${
                  currentValue === "Rennskiservice" ? "selected" : ""
                }>Rennskiservice</option>
                <option value="4" ${
                  currentValue === "Bindung montieren und einstellen"
                    ? "selected"
                    : ""
                }>Bindung montieren und einstellen</option>
                <option value="5" ${
                  currentValue === "Fell zuschneiden" ? "selected" : ""
                }>Fell zuschneiden</option>
                <option value="6" ${
                  currentValue === "Heißwachsen" ? "selected" : ""
                }>Heißwachsen</option>
              </select>`;
    } else if (index === 9) {
      // Angenommen, dies ist die Spalte für 'status'
      html = `<select class="text-sm p-1 w-full max-w-xs">
                <option value="1" ${
                  currentValue === "offen" ? "selected" : ""
                }>offen</option>
                <option value="2" ${
                  currentValue === "in Arbeit" ? "selected" : ""
                }>in Arbeit</option>
                <option value="3" ${
                  currentValue === "abgeschlossen" ? "selected" : ""
                }>abgeschlossen</option>
                <option value="4" ${
                  currentValue === "storniert" ? "selected" : ""
                }>storniert</option>
              </select>`;
    } else {
      html = `<input type="text" value="${currentValue}" class="text-sm p-1 w-full max-w-xs" />`;
    }

    cell.innerHTML = html;
  });

  const editButton = row.querySelector(".edit-button");
  const saveButton = row.querySelector(".save-button");
  const deleteButton = row.querySelector(".delete-button");
  editButton.classList.add("hidden");
  saveButton.classList.remove("hidden");
  deleteButton.classList.add("hidden");
}

function saveServiceRequest(id) {
  const row = document.querySelector(`#row-${id}`);
  if (!row) return;

  const updatedData = {
    id: id,
    Firstname: "",
    Lastname: "",
    Email: "",
    Phone: "",
    PriorityId: 0,
    CreateDate: "",
    PickupDate: "",
    ServiceId: 0,
    Price: 0.0,
    StatusId: 0,
    Comment: "",
  };

  row.querySelectorAll(".editable").forEach((cell, index) => {
    let value;

    if (cell.querySelector("input")) {
      // Es handelt sich um ein Eingabefeld
      value = cell.querySelector("input").value;
    } else if (cell.querySelector("select")) {
      // Es handelt sich um ein Dropdown-Menü
      value = cell.querySelector("select").value;
    }

    // Der Schlüsselname muss den Eigenschaftsnamen im DTO entsprechen
    switch (index) {
      case 0:
        updatedData.Lastname = value;
        break;
      case 1:
        updatedData.Firstname = value;
        break;
      case 2:
        updatedData.Email = value;
        break;
      case 3:
        updatedData.Phone = value;
        break;
      case 4:
        updatedData.Price = parseFloat(value);
        break;
      case 5:
        updatedData.CreateDate = formatDate(value);
        break;
      case 6:
        updatedData.PickupDate = formatDate(value);
        break;
      case 7:
        updatedData.ServiceId = parseInt(value);
        break;
      case 8:
        updatedData.PriorityId = parseInt(value);
        break;
      case 9:
        updatedData.StatusId = parseInt(value);
        break;
      case 10:
        updatedData.Comment = value;
        break;
    }
  });

  // Aktualisierte Daten senden
  //PUT
  fetchapi(`/api/ServiceRequests/${id}`, "PUT", updatedData)
    .then(async (response) => {
      if (!response.ok) {
        const text = await response.text();
        throw new Error(
          `Fehler: ${response.status} ${response.statusText}, Server-Antwort: ${text}`
        );
      }

      // Überprüfen, ob die Antwort JSON-Daten enthält
      const contentType = response.headers.get("Content-Type");
      if (contentType && contentType.includes("application/json")) {
        return response.json();
      }

      // Kein JSON-Inhalt
      console.log("Kein JSON-Inhalt in der Antwort");
      return null;
    })
    .then((data) => {
      if (data) {
        console.log("Update erfolgreich gesendet", data);
      } else {
        console.log("Update erfolgreich, aber keine Daten in der Antwort");
      }
      window.location.reload();
    })
    .catch((error) => {
      console.log("Gesendete Daten:", JSON.stringify(updatedData));
      console.error("Fehler beim Senden der aktualisierten Daten:", error);
    });

  // Schaltflächen zurücksetzen
  const editButton = row.querySelector(".edit-button");
  const saveButton = row.querySelector(".save-button");
  const deleteButton = row.querySelector(".delete-button");
  editButton.classList.remove("hidden");
  saveButton.classList.add("hidden");
  deleteButton.classList.remove("hidden");
}

//GET Funktion, um die aktuellen Daten eines ServiceRequests zu holen
async function getServiceRequestData(id) {
  const response = await fetch(`/api/ServiceRequests/${id}`);
  if (!response.ok) {
    throw new Error("Fehler beim Abrufen der ServiceRequest-Daten");
  }
  return await response.json();
}

// Funktion, um den Status eines ServiceRequests zu ändern
async function updateServiceRequestStatus(id, data) {
  // Hier setzen wir die StatusId auf 4 (Gelöscht)
  data.StatusId = 4;

  //TODO:
  //PUT
  const response = await fetchapi(`/api/ServiceRequests/${id}`, "PUT", data);

  if (!response.ok) {
    throw new Error("Fehler beim Aktualisieren des ServiceRequests");
  }

  // Überprüfen, ob die Antwort JSON-Daten enthält
  const contentType = response.headers.get("Content-Type");
  if (contentType && contentType.includes("application/json")) {
    return response.json();
  }

  // Kein JSON-Inhalt
  console.log("Kein JSON-Inhalt in der Antwort");
  return null;
}

// Funktion, die aufgerufen wird, wenn der "Delete"-Button geklickt wird
function deleteServiceRequest(id) {
  getServiceRequestData(id)
    .then((data) => {
      return updateServiceRequestStatus(id, data);
    })
    .then(() => {
      console.log("Status erfolgreich auf 4 gesetzt");
      window.location.reload();
    })
    .catch((error) => {
      console.error("Fehler beim Ändern des Status:", error);
    });
}

let currentSort = "default";

function toggleSort() {
  currentSort = currentSort === "default" ? "priority" : "default";
  loadAndDisplayServiceRequests(currentSort);
}

function loadAndDisplayServiceRequests(sortBy) {
  fetch(`/api/ServiceRequests?sort=${sortBy}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Netzwerkantwort war nicht ok");
      }
      return response.json();
    })
    .then((serviceRequestDTOs) => {
      // Funktion, um die Daten in Ihrer Tabelle anzuzeigen
      populateTableWithServiceRequests(serviceRequestDTOs);
    })
    .catch((error) => {
      console.error("Fehler beim Laden der Serviceanfragen:", error);
    });
}
