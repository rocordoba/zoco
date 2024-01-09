import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosAnalisis from "../components/DatosAnalisis";
import EvolucionMensual3Barras from "../components/EvolucionMensual3Barras";
import TripleGraficoAnalisis from "../components/TripleGraficoAnalisis";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";
import { DatosInicioContext } from "../context/DatosInicioContext";

const Analisis = () => {
<<<<<<< HEAD
  const { datosAnalisisContext } = useContext(DatosInicioContext);
=======
  const [datosBack, setDatosBack] = useState({});
  useEffect(() => {
   
      const token = localStorage.getItem('token');
      const userId = localStorage.getItem('userId');
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
      fetch(`/api/analisis/analisis`, {
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
>>>>>>> 941531e39e46fcbec4eaa6eeeae135b2d02a1370

  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Análisis" />
      </div>
      <div className="my-3">
        <DatosAnalisis datosBack={datosAnalisisContext} />
      </div>
      <EvolucionMensual3Barras datosBack={datosAnalisisContext} />
      <TripleGraficoAnalisis datosBack={datosAnalisisContext} />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Analisis;
