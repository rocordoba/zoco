import { useContext } from "react";
import "./Footer.css";
import { DarkModeContext } from "../context/DarkModeContext";

const Footer = () => {
  const { darkMode } = useContext(DarkModeContext)

    return (
      <footer className={darkMode ? ' bg-footer-dark container mt-auto centrado py-3' : 'bg-footer container mt-auto centrado py-3'} >
        <div>
          <div className="centrado-contenido lato-regular fs-14">
            Copyright © Zoco 2023
          </div>
        </div>
      </footer>
    );
  };
  
  export default Footer;