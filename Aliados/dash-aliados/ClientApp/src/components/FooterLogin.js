import { useContext } from "react";
import "./Footer.css";
import { DarkModeContext } from "../context/DarkModeContext";

const FooterLogin = () => {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <footer
    className="copy "
    >
      <div>
        <div className=" lato-regular fs-14">
          Copyright © Zoco 2023
        </div>
      </div>
    </footer>
  );
};

export default FooterLogin;
