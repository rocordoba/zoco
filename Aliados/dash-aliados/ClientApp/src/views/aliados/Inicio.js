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

const Inicio = ({ califico, setCalifico }) => {
  const { darkMode } = useContext(DarkModeContext);
  // de aqui saca los datos del context
    const { datosBackContext, codigoRespuesta } = useContext(DatosInicioContext);
  const [contador, setContador] = useState(0);
  const [datosMandados, setDatosMandados] = useState();
  const navegacion = useNavigate();
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

    useEffect(() => {
    
        const checkResponseCodeAndRedirect = () => {
            if (codigoRespuesta !== null && codigoRespuesta !== 200) {
                console.log(codigoRespuesta);
                navegacion("/");
                recargarPagina()
            }
        };

        checkResponseCodeAndRedirect();
    }, [codigoRespuesta]);

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
      {califico === 1 && (
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
