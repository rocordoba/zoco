import React from "react";
import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";

const TituloPagina = ({title}) => {
    const { darkMode } = useContext(DarkModeContext);

  return (
    <section className="container my-4 ">
     <button
            className={
              darkMode
                ? " bg-titulo-pagina-dark  border-0 quitar-cursor-pointer"
                : " bg-titulo-pagina border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-18">
              {title}
            </div>
          </button>
    </section>
  );
};

export default TituloPagina;
