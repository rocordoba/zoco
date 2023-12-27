import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import DatosInicio from "../components/DatosInicio";

import GraficaData from "../components/GraficaData";
import Footer from "../components/Footer";
import GraficaDataCelular from "../components/GraficaDataCelular";
import { DarkModeContext } from "../context/DarkModeContext";
import GraficaDataCelularDark from "../components/GraficaDataCelularDark";
import ComportamientoGrafica from "../components/ComportamientoGrafica";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";
// import ModalEditable from "../components/ModalEditable";
import PopUpCalificar from "../components/PopUpCalificar";

const Inicio = ({ califico, setCalifico }) => {
  const { darkMode } = useContext(DarkModeContext);
  const [datosBack, setDatosBack] = useState({});
  console.log("🚀 ~ file: Inicio.js:19 ~ Inicio ~ datosBack:", datosBack);

  const [contador, setContador] = useState(0);
  console.log(
    "🚀 ~ file: ContenidoLogin.js:31 ~ ContenidoLogin ~ contador:",
    contador,
    setContador
  );
  const [datosMandados, setDatosMandados] = useState();
  console.log(datosMandados, setDatosMandados);

  useEffect(() => {
    const token = localStorage.getItem("token");
    const userId = localStorage.getItem("userId");

    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = Math.ceil(currentDate.getDate() / 7); // Obtener la semana actual
    const comercio = "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,
      id: userId,
      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };

    if (token && userId) {
      fetch(`/api/datosinicio/base`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestData),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("");
          }
          return response.json();
        })
        .then((data) => {
          console.log("Datos recuperados:", data);
          setDatosBack(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, []);


  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel datos={datosBack} />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Inicios" />
      </div>

      <div className="my-3">
        <DatosInicio datos={datosBack} />
      </div>
      {/* <ModalEditable /> */}
      {califico === 1 && (
        <>
          <PopUpCalificar califico={califico} setCalifico={setCalifico} />
        </>
      )}
      <div className="pb-4">
        <ComportamientoGrafica datos={datosBack} />
      </div>
      <div className="d-none d-xl-block">
        <GraficaData datos={datosBack} />
      </div>
      <div className="d-xl-none d-block">
        {darkMode ? (
          <GraficaDataCelularDark datos={datosBack} />
        ) : (
          <GraficaDataCelular datos={datosBack} />
        )}
      </div>
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Inicio;
