import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import TablaCalculadora from "../../components/TablaCalculadora";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";
import { useNavigate } from "react-router-dom";
const Calculadora = () => {
    const history = useNavigate();
    function recargarPagina() {
        window.location.reload();
      
    }

    useEffect(() => {
        const verificarToken = async () => {
           
            const token = sessionStorage.getItem("token") || null;

            try {
                const response = await fetch('/api/token/token', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({ Token: token })
                });

                if (response.ok) {
                   
                 
                } else {
                   
                    if (response.status === 401 || token === null) {
                        history("/");
                        recargarPagina();
                    } else {
                        throw new Error("Respuesta no satisfactoria del servidor");
                    }
                }
            } catch (error) {
             
                console.error("Error al validar el token", error);
            }
        };

        verificarToken();
    }, [history]);
  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Calculadora" />
      </div>
      <div>
        <TablaCalculadora />
      </div>
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Calculadora;
