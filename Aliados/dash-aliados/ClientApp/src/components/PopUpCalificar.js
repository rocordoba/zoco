import React, { useState } from "react";
import { useForm } from "react-hook-form";
import "./PopUpCalificar.css";

const PopUpCalificar = () => {
  const [visible1, setVisible1] = useState(true);
  const verModalNotificacion = () => {
    setVisible1(!visible1);
  };
  const apiUrlCalifico = process.env.REACT_APP_API_CALIFICO_CALIFICO;
  const [datosCapturadosMetrica, setDatosCapturadosMetrica] = useState({});

  const { register, handleSubmit, reset } = useForm();
  const [califico, setCalifico] = useState();

  const onSubmit = async (datos) => {
    const token = sessionStorage.getItem("token");

    const datosEnviar = {
      Token: token,
      NumCalifico: datos.radio,
      Fecha: new Date().toISOString(),
    };

    setDatosCapturadosMetrica(datos);
    setCalifico(1);
    reset();
    verModalNotificacion();

    try {
      const response = await fetch(apiUrlCalifico, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(datosEnviar),
      });

      if (!response.ok) {
        throw new Error("Error al enviar los datos");
      }
    } catch (error) {
      console.error("Hubo un error:", error);
    }
  };

  const [isActive, setIsActive] = useState(false);

  return (
    <div>
      <>
        {visible1 && (
          <div className="modalShadow centrado">
            <div className="centrado caja-popup">
              <div className="">
                <div className=" ">
                  <h6 className="lato-bold fs-24-a-18  color-verde mb-5">
                    ¡Queremos saber tu opinión!{" "}
                  </h6>
                  <h6 className=" fs-16-a-14">
                    En base a tu última experiencia con tu Asesor Consultor,{" "}
                    <br />
                    ¿qué tan probable es que recomiendes Zoco - Servicios <br />{" "}
                    de pago a otras personas?
                  </h6>
                  <div className="d-flex justify-content-center">
                    <form
                      className="width-personalizado-form-popup"
                      onSubmit={handleSubmit(onSubmit)}
                    >
                      <div className="d-none d-md-block">
                        <section className="d-flex form-metrica ">
                          <div>
                            <div>
                              <h6 className="fs-16-a-14">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault1"
                            >
                              1
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault1"
                                id="flexRadioDefault1"
                                value="1"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault2"
                            >
                              2
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault2"
                                id="flexRadioDefault2"
                                value="1"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault3"
                            >
                              3
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault3"
                                id="flexRadioDefault3"
                                value="3"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault4"
                            >
                              4
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault4"
                                id="flexRadioDefault4"
                                value="4"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault5"
                            >
                              5
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault5"
                                id="flexRadioDefault5"
                                value="5"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault6"
                            >
                              6
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault6"
                                id="flexRadioDefault6"
                                value="6"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault7"
                            >
                              7
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault7"
                                id="flexRadioDefault7"
                                value="7"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault8"
                            >
                              8
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault8"
                                id="flexRadioDefault8"
                                value="8"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6>poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault9"
                            >
                              9
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault9"
                                id="flexRadioDefault9"
                                value="9"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="">
                              <h6 className=" fs-16">Muy probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-16 "
                              for="flexRadioDefault10"
                            >
                              10
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input"
                                type="radio"
                                name="flexRadioDefault10"
                                id="flexRadioDefault10"
                                value="10"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                        </section>
                      </div>
                      <div className="d-md-none d-block">
                        <section className="d-flex">
                          <div className="">
                            <div>
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12 "
                              for="flexRadioDefault1"
                            >
                              1
                            </label>
                            <div>
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault1"
                                id="flexRadioDefault1"
                                value="1"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12 "
                              for="flexRadioDefault2"
                            >
                              2
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault2"
                                id="flexRadioDefault2"
                                value="1"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12 "
                              for="flexRadioDefault3"
                            >
                              3
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault3"
                                id="flexRadioDefault3"
                                value="3"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12"
                              for="flexRadioDefault4"
                            >
                              4
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault4"
                                id="flexRadioDefault4"
                                value="4"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12"
                              for="flexRadioDefault5"
                            >
                              5
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault5"
                                id="flexRadioDefault5"
                                value="5"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                        </section>
                        <section className="d-flex">
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12 "
                              for="flexRadioDefault6"
                            >
                              6
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault6"
                                id="flexRadioDefault6"
                                value="6"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12 "
                              for="flexRadioDefault7"
                            >
                              7
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault7"
                                id="flexRadioDefault7"
                                value="7"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12 "
                              for="flexRadioDefault8"
                            >
                              8
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault8"
                                id="flexRadioDefault8"
                                value="8"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="ocultar-texto-div">
                              <h6 className="fs-12">poco probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12"
                              for="flexRadioDefault9"
                            >
                              9
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault9"
                                id="flexRadioDefault9"
                                value="9"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                          <div className="">
                            <div className="">
                              <h6 className="fs-12">Muy probable</h6>
                            </div>
                            <label
                              className="lato-bold fs-12"
                              for="flexRadioDefault10"
                            >
                              10
                            </label>
                            <div className=" ">
                              <input
                                onClick={() => setIsActive(!isActive)}
                                className="form-check-input fs-12"
                                type="radio"
                                name="flexRadioDefault10"
                                id="flexRadioDefault10"
                                value="10"
                                {...register("radio")}
                              />
                            </div>
                          </div>
                        </section>
                      </div>
                      <div className="my-5">
                        <button
                          disabled={isActive === false && true}
                          className="btn-popUp lato-bold fs-18"
                          type="submit"
                        >
                          Continuar
                        </button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
          </div>
        )}
      </>
    </div>
  );
};

export default PopUpCalificar;
