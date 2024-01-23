import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import DatosAnalisis from "../../components/DatosAnalisis";
import EvolucionMensual3Barras from "../../components/EvolucionMensual3Barras";
import TripleGraficoAnalisis from "../../components/TripleGraficoAnalisis";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";
import { DatosInicioContext } from "../../context/DatosInicioContext";
import { useNavigate } from "react-router-dom";
import Swal from "sweetalert2";
const Analisis = () => {
  const { datosAnalisisContext, codigoRespuesta } =
    useContext(DatosInicioContext);
  const navegacion = useNavigate();
  const history = useNavigate();
  function recargarPagina() {
    window.location.reload();
  }
  const apiUrlToken = process.env.REACT_APP_API_TOKEN;

  useEffect(() => {
    const verificarToken = async () => {
      const token = sessionStorage.getItem("token");

      try {
        const response = await fetch(apiUrlToken, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ Token: token }),
        });

        if (response.ok) {
        } else {
          if (response.status === 401 || token === null) {
            Swal.fire({
              title: "Sesión expirada.",
              text: "Inicie sesión nuevamente.",
              icon: "error",
              confirmButtonText: "Ok",
            }).then((result) => {
              if (result.isConfirmed) {
                // Aquí manejas la navegación y la recarga de la página después de que el usuario hace clic en "Ok"
                navegacion("/");
                recargarPagina();
              }
            });
          } else {
            throw new Error("Respuesta no satisfactoria del servidor");
          }
        }
      } catch (error) {
        console.error("Error al validar el token", error);
      }
    };

    const checkResponseCodeAndRedirect = () => {
      if (codigoRespuesta !== null && codigoRespuesta !== 200) {
        
        Swal.fire({
          title: "Sesión expirada.",
          text: "Inicie sesión nuevamente.",
          icon: "error",
          confirmButtonText: "Ok",
        }).then((result) => {
          if (result.isConfirmed) {
            // Aquí manejamos la navegación y la recarga de la página después de que el usuario hace clic en "Ok"
            navegacion("/");
            recargarPagina();
          }
        });
      }
    };

    verificarToken();
    checkResponseCodeAndRedirect();
  }, [history, codigoRespuesta]);
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
