async function fetchapi(endpoint, method, body) {
  const hasAuth = localStorage.getItem("token");
  const headers = {
    "Content-Type": "application/json",
  };
  if (hasAuth) {
    headers["Authorization"] = "Bearer " + hasAuth;
  }
  return await fetch(endpoint, {
    method,
    body: JSON.stringify(body),
    headers,
  });
}

function main() {
  var themeToggleBtn = document.getElementById("theme-toggle");
  var themeToggleIcon = document.getElementById("theme-toggle-icon");

  function setLogo(path) {
    document.querySelectorAll(".logo").forEach((logo) => {
      logo.src = path;
    });
  }

  // Change the icons inside the button based on previous settings
  function setThemeDark() {
    if (themeToggleIcon.classList.contains("material-fill")) {
      themeToggleIcon.classList.remove("material-fill");
    }
    document.body.classList.add("dark");
    setLogo("./assets/img/logo_white.png");
  }

  function setThemeLight() {
    if (!themeToggleIcon.classList.contains("material-fill")) {
      themeToggleIcon.classList.add("material-fill");
    }
    document.body.classList.remove("dark");
    setLogo("./assets/img/logo.png");
  }

  if (
    localStorage.getItem("color-theme") === "dark" ||
    (!("color-theme" in localStorage) &&
      window.matchMedia("(prefers-color-scheme: dark)").matches)
  ) {
    setThemeDark();
  } else {
    setThemeLight();
  }

  const toggleButton = document.querySelector(
    '[data-collapse-toggle="navbar-default"]'
  );
  const navbarMenu = document.getElementById("navbar-menu");

  toggleButton.addEventListener("click", () => {
    navbarMenu.classList.toggle("hidden");
    navbarMenu.classList.toggle("block");
  });
  themeToggleBtn.addEventListener("click", function () {
    // toggle icons inside button

    // if set via local storage previously
    if (localStorage.getItem("color-theme")) {
      if (localStorage.getItem("color-theme") === "light") {
        setThemeDark();
        localStorage.setItem("color-theme", "dark");
      } else {
        setThemeLight();
        localStorage.setItem("color-theme", "light");
      }

      // if NOT set via local storage previously
    } else {
      if (document.body.classList.contains("dark")) {
        setThemeLight();
        localStorage.setItem("color-theme", "light");
      } else {
        setThemeDark();
        localStorage.setItem("color-theme", "dark");
      }
    }
  });
  handleNavbar();
  getWrapperHeight();
}

function setActiveNavigation(name) {
  // Entfernen der 'active' Klasse von allen Links
  document.querySelectorAll(`a[data-page="*"]`).forEach((elm) => {
    elm.classList.remove("active");
  });

  // Hinzufügen der 'active' Klasse zum spezifischen Link, falls vorhanden
  const activeLink = document.querySelector(`a[data-page="${name}"]`);
  if (activeLink) {
    activeLink.classList.add("active");
  }
}

function handleNavbar() {
  const relativePath = window.location.pathname;

  switch (relativePath) {
    case "/index.html":
      setActiveNavigation("index");
      break;

    case "/":
      setActiveNavigation("index");
      break;

    case "/about.html":
      setActiveNavigation("about");
      break;

    case "/form.html":
      setActiveNavigation("form");
      break;

    case "/services.html":
      setActiveNavigation("services");
      break;

    case "/contact.html":
      setActiveNavigation("contact");
      break;

    case "/login.html":
      setActiveNavigation("login");
      break;

    case "/orders.html":
      setActiveNavigation("orders");
      break;

    case "/employees.html":
      setActiveNavigation("employees");
      break;

    default:
      setActiveNavigation("/");
      break;
  }
}

function getWrapperHeight() {
  // Höhe der Navigation ermitteln
  var navHeight = document.querySelector("nav").offsetHeight;
  setMargin("form-wrapper", navHeight);
  setMargin("services-wrapper", navHeight);
  setMargin("index-wrapper", navHeight);
  setMargin("contact-wrapper", navHeight);
  setMargin("about-wrapper", navHeight);
  setMargin("policies-wrapper", navHeight);
}

function setMargin(name, height) {
  const elm = document.getElementById(name);
  if (elm) {
    elm.style.marginTop = height + "px";
  }
}
// Aufruf der Hauptfunktion, wenn das Fenster geladen wird

document.addEventListener("DOMContentLoaded", main);
