import { faArrowRightArrowLeft } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { DarkModeContext } from "../context/DarkModeContext";
import { Form } from "react-bootstrap";
import Select from "react-select";

const optionsTarjeta = [
  { value: "Tarjeta 1", label: "Tarjeta 1" },
  { value: "Tarjeta 2", label: "Tarjeta 2" },
  { value: "Tarjeta 3", label: "Tarjeta 3" },
  { value: "Tarjeta 4", label: "Tarjeta 4" },
];

const DatosCal = () => {
  const [datosCapturadosCalculadora, setDatosCapturadosCalculadora] = useState(
    {}
  );
  const { control, handleSubmit, register } = useForm();

  const onSubmit = (datos) => {
    setDatosCapturadosCalculadora(datos);
  };

  const { darkMode } = useContext(DarkModeContext);
  const [neto, setNeto] = useState("");
  const [bruto, setBruto] = useState(Math.trunc(neto * 1.1));
  const [esMontoA, setEsMontoA] = useState(true);
  const intercambiarValores = () => {
    setEsMontoA(!esMontoA);
  };

  const handleNetoChange = (e) => {
    const newNeto = e.target.value;
    setNeto(newNeto);
    const newBruto = Math.trunc(newNeto * 1.1);
    setBruto(newBruto);
  };

  const [isSearchable, setIsSearchable] = useState(true);
  const [selectedTarjeta, setSelectedTarjeta] = useState(null);

  return (
    <div>
      <article>
        <form
          className="d-flex justify-content-between flex-wrap container"
          onSubmit={handleSubmit(onSubmit)}
        >
          {/* NETO/BRUTO ESCRITORIO */}
          {esMontoA ? (
            <section>
              <div className="d-flex">
                <article className="">
                  <div className="">
                    <h6 className="text-center lato-bold fs-17"> Neto</h6>
                    <div className=" d-flex justify-content-center border-0">
                      <input
                        id="miid"
                        className={
                          darkMode
                            ? "form-control ingresar-neto-dark px-5 border-0 text-white "
                            : "form-control ingresar-neto px-5 border-0"
                        }
                        type="number"
                        placeholder="Ingresa el monto"
                        aria-label="Search"
                        {...register("netoBuscar", {})}
                        value={neto}
                        onChange={handleNetoChange}
                      />
                    </div>
                  </div>
                </article>
                <div className="mx-3">
                  <button
                    onClick={intercambiarValores}
                    className={
                      darkMode
                        ? "border-0 btn-transparent"
                        : "border-0 btn-transparent"
                    }
                  >
                    <FontAwesomeIcon
                      className="color-verde fs-5"
                      icon={faArrowRightArrowLeft}
                    />
                  </button>
                  <div className="my-3">
                    <h5 className="lato-bold  fs-4">=</h5>
                  </div>
                </div>

                <article className="">
                  <h6 className="text-center lato-bold fs-17"> Bruto</h6>
                  <button
                    className={
                      darkMode
                        ? " ingresar-neto-dark border-0 quitar-cursor-pointer"
                        : "ingresar-neto border-0 quitar-cursor-pointer"
                    }
                  >
                    <div className=" d-flex justify-content-center border-0">
                      <input
                        id="miid"
                        className={
                          darkMode
                            ? "form-control ingresar-neto-dark px-5 border-0 text-white "
                            : "form-control ingresar-neto px-5 border-0"
                        }
                        type="number"
                        placeholder="Ingresa el monto"
                        disabled
                        aria-label="Search"
                        {...register("brutoBuscar", {})}
                        value={bruto}
                        onChange={handleNetoChange}
                      />
                    </div>
                  </button>
                </article>
              </div>
            </section>
          ) : (
            <section>
              <div className="d-flex">
                <article className="">
                  <h6 className="text-center lato-bold fs-17"> Bruto</h6>
                  <button
                    className={
                      darkMode
                        ? " ingresar-neto-dark border-0 quitar-cursor-pointer"
                        : "ingresar-neto border-0 quitar-cursor-pointer"
                    }
                  >
                    <div className=" d-flex justify-content-center border-0">
                      <input
                        id="miid"
                        className={
                          darkMode
                            ? "form-control ingresar-neto-dark px-5 border-0 text-white "
                            : "form-control ingresar-neto px-5 border-0"
                        }
                        type="number"
                        placeholder="Ingresa el monto"
                        aria-label="Search"
                        {...register("brutoBuscar", {})}
                        value={bruto}
                        onChange={handleNetoChange}
                      />
                    </div>
                  </button>
                </article>
                <div className="mx-3">
                  <button
                    onClick={intercambiarValores}
                    className={
                      darkMode
                        ? "border-0 btn-transparent"
                        : "border-0 btn-transparent"
                    }
                  >
                    <FontAwesomeIcon
                      className="color-verde fs-5"
                      icon={faArrowRightArrowLeft}
                    />
                  </button>
                  <div className="my-3">
                    <h5 className="lato-bold  fs-4">=</h5>
                  </div>
                </div>
                <article className="">
                  <div className="">
                    <h6 className="text-center lato-bold fs-17"> Neto</h6>
                    <div className=" d-flex justify-content-center border-0">
                      <input
                        id="miid"
                        className={
                          darkMode
                            ? "form-control ingresar-neto-dark px-5 border-0 text-white "
                            : "form-control ingresar-neto px-5 border-0"
                        }
                        type="number"
                        disabled
                        placeholder="Ingresa el monto"
                        aria-label="Search"
                        {...register("netoBuscar", {})}
                        value={neto}
                        onChange={handleNetoChange}
                      />
                    </div>
                  </div>
                </article>
              </div>
            </section>
          )}
          <div className="d-flex pt-5 ">
            <div className="form-check me-4 ">
              <input
                className="form-check-input"
                type="radio"
                name="flexRadioDefault1"
                id="flexRadioDefault1"
                value="Debito"
                defaultChecked
                {...register("radio")}
              />
              <label
                className="form-check-label lato-bold fs-16"
                for="flexRadioDefault1"
              >
                Débito
              </label>
            </div>
            <div className="form-check">
              <input
                className="form-check-input"
                type="radio"
                name="flexRadioDefault1"
                id="flexRadioDefault2"
                value="Credito"
                {...register("radio")}
              />
              <label
                className="form-check-label lato-bold fs-16"
                for="flexRadioDefault2"
              >
                Crédito
              </label>
            </div>
          </div>
          <article className="my-3">
            <label
              htmlFor="exampleFormControlInput1"
              className="lato-bold fs-16 ms-3"
            >
              Tarjeta
            </label>
            <Select
              value={selectedTarjeta}
              defaultInputValue={"Todos"}
              className="select__control_custom lato-bold"
              classNamePrefix="select"
              isSearchable={isSearchable}
              name="tarjeta"
              options={optionsTarjeta}
              onChange={(selectedOption) => setSelectedTarjeta(selectedOption)}
              styles={{
                control: (base) => ({
                  ...base,
                  textAlign: "center",
                }),
              }}
            />
          </article>
          <div className="pt-4">
            <button
              className="btn-calculadora text-white border-0"
              type="submit"
            >
              <div className="d-flex justify-content-center border-0">
                <span className="text-white lato-bold fs-18"> Calcular</span>
              </div>
            </button>
          </div>
        </form>
      </article>
    </div>
  );
};

export default DatosCal;
