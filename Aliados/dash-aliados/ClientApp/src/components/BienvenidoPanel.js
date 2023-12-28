import React, { useContext, useState } from "react";
import Select from "react-select";
import './BienvenidoPanel.css';
import { DarkModeContext } from "../context/DarkModeContext";
const optionsAnios = [
  { value: "2023", label: "2023" },
  { value: "2022", label: "2022" },
  { value: "2021", label: "2021" },
];

const optionsMes = [
  { value: "enero", label: "Enero" },
  { value: "febrero", label: "Febrero" },
  { value: "marzo", label: "Marzo" },
  { value: "abril", label: "Abril" },
  { value: "mayo", label: "Mayo" },
  { value: "junio", label: "Junio" },
  { value: "julio", label: "Julio" },
  { value: "agosto", label: "Agosto" },
  { value: "septiembre", label: "Septiembre" },
  { value: "octubre", label: "Octubre" },
  { value: "noviembre", label: "Noviembre" },
  { value: "diciembre", label: "Diciembre" },
];

const optionsComercio = [
  { value: "Todos", label: "Todos" },
  { value: "craft", label: "Craft" },
  { value: "la Bandeña", label: "La Bandeña" },
  { value: "casapan", label: "Casapan" },
];

const optionsSemanas = [
  { value: "semana 1-7", label: "1-7" },
  { value: "semana 7-14", label: "7-14" },
  { value: "semana 14-21", label: "14-21" },
  { value: "semana 21-28", label: "21-28" },
  { value: "semana 28-31", label: "28-31" },
];

const BienvenidoPanel = ({datos }) => {
  const { darkMode } = useContext(DarkModeContext);
  const [datoCapturados, setDatoCapturados] = useState({})
  const [isSearchable, setIsSearchable] = useState(true);
  const [selectedAnio, setSelectedAnio] = useState(null);
  const [selectedMes, setSelectedMes] = useState(null);
  const [selectedComercio, setSelectedComercio] = useState(null);
  const [selectedSemana, setSelectedSemana] = useState(null);

  const handleEnviarDatos = () => {
    // Aquí puedes preparar los datos para enviar al backend
    //  AñoActual = añoActual,
      //    MesesHastaHoy = mesesHastaHoy,
        //  SemanasPorMes = semanasPorMes,
        //Fantasiasnombre = fantasiasnombre
    const data = {
      anio: selectedAnio?.value,
      mes: selectedMes?.value,
      comercio: selectedComercio?.value,
      semana: selectedSemana?.value,
    };
    setDatoCapturados(data)
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
                    defaultInputValue={"2023"}
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="anio"
                    options={optionsAnios}
                    onChange={(selectedOption) =>
                      setSelectedAnio(selectedOption)
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
                    Mes
                  </label>
                  <Select
                    value={selectedMes}
                    defaultInputValue={"Octubre"}
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="mes"
                    options={optionsMes}
                    onChange={(selectedOption) =>
                      setSelectedMes(selectedOption)
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
                    defaultInputValue={ "Todos"}
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
                <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Semanas
                  </label>
                  <Select
                    value={selectedSemana}
                    defaultInputValue={"1-7"}
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