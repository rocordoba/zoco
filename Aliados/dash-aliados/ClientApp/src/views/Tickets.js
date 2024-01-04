import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosTickets from "../components/DatosTickets";
import TablaTickets from "../components/TablaTickets";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";


const Tickets = () => {
    const [datosBack, setDatosBack] = useState({});
    const {listaMes} = datosBack;

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
            fetch(`/api/cupones/cupones`, {
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
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Cupones" />
      </div>
      <div className="my-3">
        <DatosTickets />
      </div>
      <TablaTickets listaMes={listaMes} />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Tickets;
