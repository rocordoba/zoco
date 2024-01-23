import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import DatosInicio from "../../components/DatosInicio";

import GraficaData from "../../components/GraficaData";
import Footer from "../../components/Footer";
import GraficaDataCelular from "../../components/GraficaDataCelular";
import { DarkModeContext } from "../../context/DarkModeContext";
import GraficaDataCelularDark from "../../components/GraficaDataCelularDark";
import ComportamientoGrafica from "../../components/ComportamientoGrafica";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";
// import ModalEditable from "../components/ModalEditable";
import PopUpCalificar from "../../components/PopUpCalificar";
import { DatosInicioContext } from "../../context/DatosInicioContext";
import { useNavigate } from "react-router-dom";
import Swal from "sweetalert2";

const Inicio = ({ califico, setCalifico }) => {
  const { darkMode } = useContext(DarkModeContext);
  // de aqui saca los datos del context
  const { datosBackContext, codigoRespuesta } = useContext(DatosInicioContext);
  const [contador, setContador] = useState(0);
  const [datosMandados, setDatosMandados] = useState();
  const navegacion = useNavigate();
  const history = useNavigate();
  const [estadoCalifico, setEstadoCalifico] = useState(null);
  function recargarPagina() {
    window.location.reload();
  }
  const apiUrlToken = process.env.REACT_APP_API_TOKEN;
  const apiUrlCalifico = process.env.REACT_APP_API_CALIFICAR_COM;

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
          // Llama a obtenerCalifico solo si el token es v�lido
          obtenerCalifico(token);
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
        console.log(codigoRespuesta);
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

    const obtenerCalifico = async (token) => {
      try {
        const response = await fetch(apiUrlCalifico, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ Token: token }),
        });

        if (response.ok) {
          const resultadoCalifico = await response.json();

          
          setEstadoCalifico(resultadoCalifico); // Actualiza el nuevo estado
        } else {
          throw new Error("Error al obtener califico");
        }
      } catch (error) {
        console.error("Error en la solicitud de califico", error);
      }
    };

    verificarToken();
    checkResponseCodeAndRedirect();
  }, [history, codigoRespuesta, setCalifico]); // Aseg�rate de incluir todas las dependencias necesarias

  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel datos={datosBackContext} />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Inicio" />
      </div>

      <div className="my-3">
        <DatosInicio datos={datosBackContext} />
      </div>
      {/* <ModalEditable /> */}
      {estadoCalifico === false && (
        <>
          <PopUpCalificar califico={califico} setCalifico={setCalifico} />
        </>
      )}
      <div className="pb-4">
        <ComportamientoGrafica datos={datosBackContext} />
      </div>
      <div className="d-none d-xl-block">
        <GraficaData datos={datosBackContext} />
      </div>
      <div className="d-xl-none d-block">
        {darkMode ? (
          <GraficaDataCelularDark datos={datosBackContext} />
        ) : (
          <GraficaDataCelular datos={datosBackContext} />
        )}
      </div>
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Inicio;
