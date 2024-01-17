import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import FormComentarioCalificar from "../../components/FormComentarioCalificar";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";
import { useNavigate } from "react-router-dom";
const Calificar = () => {
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
                    
                    console.log("Token válido");
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
        <TituloPagina title="Calificar" />
      </div>
      <div className="my-4">
        <FormComentarioCalificar />
      </div>
      <div style={{ paddingBottom: "4rem", paddingTop: "4rem" }}>
        <Footer />
      </div>
    </div>
  );
};

export default Calificar;
