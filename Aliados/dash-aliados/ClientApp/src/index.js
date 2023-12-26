import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { DarkModeProvider } from "./context/DarkModeContext";
import "bootstrap/dist/js/bootstrap.bundle.min.js"; 
import "bootstrap/dist/css/bootstrap.min.css";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <DarkModeProvider>
    <App />
  </DarkModeProvider>
);
