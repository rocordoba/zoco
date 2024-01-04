import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosContabilidad from "../components/DatosContabilidad";
import ImpuestosCards from "../components/ImpuestosCards";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";

const Contabilidad = () => {

  
  const [datosBack, setDatosBack] = useState({});
  console.log("🚀 ~ file: Contabilidad.js:11 ~ Contabilidad ~ datosBack:", datosBack)
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
      fetch(`/api/contablidad/contabilidad`, {
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
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Contabilidad" />
      </div>
      <div className="my-3">
        <DatosContabilidad datosBack={datosBack} />
      </div>
      <ImpuestosCards />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Contabilidad;
