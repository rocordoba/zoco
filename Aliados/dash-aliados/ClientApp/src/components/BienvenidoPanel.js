import React, { useContext, useEffect, useState } from "react";
import Select from "react-select";
import "./BienvenidoPanel.css";
import { DarkModeContext } from "../context/DarkModeContext";
import { DatosInicioContext } from "../context/DatosInicioContext";
import Swal from "sweetalert2";


const BienvenidoPanel = () => {
  const { darkMode } = useContext(DarkModeContext);
  const [datoCapturados, setDatoCapturados] = useState({});
  const [isSearchable, setIsSearchable] = useState(true);
  const [selectedAnio, setSelectedAnio] = useState(null);
  const [selectedMes, setSelectedMes] = useState(null);
  const [selectedComercio, setSelectedComercio] = useState(null);
  const [selectedSemana, setSelectedSemana] = useState(null);

  const { actualizarDatos } = useContext(DatosInicioContext);
    const [fechaInicio, setFechaInicio] = useState(null);
    const [fechaFin, setFechaFin] = useState(null);
    const [optionsComercio, setOptionsComercio] = useState([]);
    const [optionsAnios, setOptionsAnios] = useState([]);
    const [optionsMes, setOptionsMes] = useState([]);
    const [optionsSemanas, setOptionsSemanas] = useState([]);
  //const notificacionesHardcodeado = {
  //  anio: 2023,
  //  mes: 12,
  //  comercio: "Todos",
  //  semana: 3,
  //}

    const enviarDatosAlContexto = (datos) => {
        // Utiliza 'datos' para hacer lo que necesites
        actualizarDatos(datos);
    };

    const procesarDatos = (data) => {
        console.log("Respuesta de la API:", data);

      
        const optionsComercio = data.comercios.map(comercio => ({
            value: comercio.toLowerCase().replace(/\s+/g, ''),
            label: comercio
        }));

       
        const fechaInicio = new Date(data.fechaInicio);
        const fechaFin = new Date(data.fechaFin);

        const optionsAnios = [];
        for (let año = fechaInicio.getFullYear(); año <= fechaFin.getFullYear(); año++) {
            optionsAnios.push({ value: año.toString(), label: año.toString() });
        }

        const optionsMeses = [];
        let fechaActual = fechaInicio;
        while (fechaActual <= fechaFin) {
            const mes = fechaActual.toLocaleString('es', { month: 'long' });
            optionsMeses.push({ value: mes.toLowerCase(), label: mes });
            fechaActual = new Date(fechaActual.getFullYear(), fechaActual.getMonth() + 1, 1);
        }



       
        setOptionsComercio(optionsComercio);
        setOptionsAnios(optionsAnios);
        setOptionsMes(optionsMeses);
        setOptionsSemanas(optionsSemanas);
        setFechaInicio(fechaInicio);
        setFechaFin(fechaFin);
    
    };



    useEffect(() => {
     
        const token = sessionStorage.getItem("token");
        const userId = localStorage.getItem("userId");

      
        const requestData = {
            token: token,
            id: userId,
        };


        if (token && userId) {
     
            fetch('/api/bienvenidopanel/bienvenidopanel', {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(requestData),
            })
                .then((response) => {
                    if (!response.ok) {
                        throw new Error("Error en la solicitud");
                    }
                    return response.json();
                })
                .then((data) => {
                    console.log("Datos recibidos de la API:", data);
                    procesarDatos(data); 
                })
                .catch((error) => {
                    console.error("Error en la solicitud:", error);
                });
        }
    }, []);
    const actualizarMesesPorAnio = (anioSeleccionado) => {
        if (!fechaInicio || !fechaFin) return;
     
        const mesInicio = (new Date(anioSeleccionado, 0, 1)).getFullYear() === fechaInicio.getFullYear() ? fechaInicio.getMonth() : 0;
        

   
        const mesFin = fechaFin.getMonth() >= mesInicio ? fechaFin.getMonth() : 11;

        const optionsMeses = [];
        for (let mes = mesInicio; mes <= mesFin; mes++) {
            let fechaActual = new Date(anioSeleccionado, mes, 1);
            const nombreMes = fechaActual.toLocaleString('es', { month: 'long' });
            optionsMeses.push({ value: nombreMes.toLowerCase(), label: nombreMes });
        }

        setOptionsMes(optionsMeses);
        setSelectedMes(null);
    };
    const actualizarSemanasPorMes = (anioSeleccionado, mesSeleccionado) => {
        const meses = {
            enero: 0, febrero: 1, marzo: 2, abril: 3, mayo: 4, junio: 5,
            julio: 6, agosto: 7, septiembre: 8, octubre: 9, noviembre: 10, diciembre: 11
        };

        const primerDiaMes = new Date(anioSeleccionado, meses[mesSeleccionado], 1);
        const ultimoDiaMes = new Date(anioSeleccionado, meses[mesSeleccionado] + 1, 0);

        let diaActual = new Date(primerDiaMes.getTime());
        let semanas = [];
        let semana = [];
        let numeroSemana = 0;

        if (diaActual < fechaInicio) {
            diaActual = new Date(fechaInicio.getTime());
        }

        if (diaActual.getDay() !== 1) {
            let diaInicioSemana = new Date(diaActual);
            diaInicioSemana.setDate(diaInicioSemana.getDate() - diaActual.getDay() + 1);

            for (let d = new Date(diaInicioSemana); d < diaActual; d.setDate(d.getDate() + 1)) {
                semana.push(new Date(d));
            }
        }

        for (let d = new Date(diaActual); d <= ultimoDiaMes && d <= fechaFin; d.setDate(d.getDate() + 1)) {
            semana.push(new Date(d));
            if (d.getDay() === 0 || d.getDate() === ultimoDiaMes.getDate() || d.getDate() === fechaFin.getDate()) {
                numeroSemana++;
                semanas.push({ semana: numeroSemana, dias: [...semana] });
                semana = [];
            }
        }

        
        const semanasFormateadas = semanas.map(semana => {
            const inicioSemana = semana.dias[0];
            const finSemana = semana.dias[semana.dias.length - 1];
            const opcionesFormato = { day: '2-digit', month: 'long' };
            const label = `${inicioSemana.toLocaleDateString('es-ES', opcionesFormato)} - ${finSemana.toLocaleDateString('es-ES', opcionesFormato)}`;
            const value = semana.semana; 

            console.log(value); 

            return { label, value };
        });

        setOptionsSemanas(semanasFormateadas);
    };





  const [notificaciones, setNotificaciones] = useState({
    anios: [],
    meses: [],
    semanas: [],
    comercios: []
  });




    const handleEnviarDatos = () => {
        if (!selectedAnio || !selectedMes || !selectedSemana || !selectedComercio) {
         
            Swal.fire({
                title: "Error",
                text: "Por favor, selecciona todos los campos.",
                icon: "error",
                confirmButtonText: "Ok",
            });
            return; 
        }

        const data = {
            anio: selectedAnio.value,
            mes: selectedMes.value,
            comercio: selectedComercio.value,
            semana: selectedSemana.value,
        };

        setDatoCapturados(data);
        enviarDatosAlContexto(data); 

        // Mostrar SweetAlert2 aquí
        Swal.fire({
            title: "¡Filtrado!",
            icon: "success",
            confirmButtonText: "Ok",
        });
    };


  return (
    <section
      className={
        darkMode
          ? " contenedor-panel-control-dark py-4   container"
          : "py-4  contenedor-panel-control container"
      }
    >
      <div className="">
        <div className="row">
          <div className="col-md-2  my-3 ">
            <h6 className="text-center heavy-900 fs-16 ms-2">
              {" "}
              Bienvenido/a al <br />{" "}
              <span className="text-center heavy-900 color-verde fs-25 line-h-26">
                {" "}
                Panel de Control
              </span>{" "}
            </h6>
          </div>

          <div className="col-md-10 ">
            <div>
              <article className="borde-caja-panel"></article>
              <form className="d-flex justify-content-around">
                              <article>
                                  <label
                                      htmlFor="exampleFormControlInput1"
                                      className="lato-bold fs-16 ms-3 "
                                  >
                                      Año
                                  </label>
                                  <Select
                                      value={selectedAnio}
                                      className="select__control_custom lato-bold"
                                      classNamePrefix="select"
                                      isSearchable={isSearchable}
                                      name="anio"
                                      options={optionsAnios} 
                                      onChange={(selectedOption) => {
                                          setSelectedAnio(selectedOption);
                                          actualizarMesesPorAnio(selectedOption.value); 
                                      }}
                                      styles={{
                                          control: (base) => ({
                                              ...base,
                                              textAlign: "center",
                                          }),
                                      }}
                                  />
                              </article>
                <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Mes
                  </label>
                  <Select
                                      value={selectedMes}
                                      className="select__control_custom lato-bold"
                                      classNamePrefix="select"
                                      isSearchable={isSearchable}
                                      name="mes"
                                      options={optionsMes}
                                      onChange={(selectedOption) => {
                                          setSelectedMes(selectedOption);
                                          actualizarSemanasPorMes(selectedAnio.value, selectedOption.label);
                                      }}
                    styles={{
                      control: (base) => ({
                        ...base,
                        textAlign: "center",
                      }),
                    }}
                  />
                </article>
                <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Semanas
                  </label>
                  <Select
                    value={selectedSemana}
                                      
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="semanas"
                    options={optionsSemanas}
                    onChange={(selectedOption) =>
                      setSelectedSemana(selectedOption)
                    }
                    styles={{
                      control: (base) => ({
                        ...base,
                        textAlign: "center",
                      }),
                    }}
                  />
                </article>
                <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Comercio
                  </label>
                  <Select
                    value={selectedComercio}
                    defaultInputValue={"Todos"}
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="comercio"
                    options={optionsComercio}
                    onChange={(selectedOption) =>
                      setSelectedComercio(selectedOption)
                    }
                    styles={{
                      control: (base) => ({
                        ...base,
                        textAlign: "center",
                      }),
                    }}
                  />
                </article>
               
                <div className="mt-4 me-1">
                  <button
                    className="cursor-point ov-btn-slide-left border-0 lato-bold fs-16 text-white"
                    type="button"
                    onClick={handleEnviarDatos}
                  >
                    Aplicar
                  </button>
                </div>
                
              </form>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default BienvenidoPanel;