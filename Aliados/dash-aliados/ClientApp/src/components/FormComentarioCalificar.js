import { faStar } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useContext, useState } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import "./FormComentarioCalificar.css";
import { Col, Form } from "react-bootstrap";
import Swal from "sweetalert2";

const FormComentarioCalificar = () => {
  const [rating, setRating] = useState(0);
  const [formComentarioData, setFormComentarioData] = useState({
    comentario: "",
  });
  const apiUrlClave = process.env.REACT_APP_API_CAMBIAR_CLAVE;

  const isButtonDisabled = rating === 0;

  const handleStarClick = (star) => {
    setRating(star);
  };
  const onSubmit = async (event) => {
    event.preventDefault();
    const token = sessionStorage.getItem("token");
    const userId = parseInt(localStorage.getItem("userId")); // Asegúrate de que userId sea un entero
    const fechaActual = new Date().toISOString();

    const datosConRating = {
      Token: token,
      UsuarioId: userId,
      NumCalifico: rating,
      Descripcion: formComentarioData.comentario,
      Fecha: fechaActual,
    };

    //  console.log("Datos a enviar:", datosConRating);

    try {
      await fetch("/api/califico/calificocom", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(datosConRating),
      });

      // No hay lógica adicional después de la solicitud, por lo que no se espera respuesta
      setRating(0);
      setFormComentarioData({ comentario: "" });

      // Mostrar SweetAlert2 aquí
      Swal.fire({
        title: "¡Enviado!",
        text: "Tu comentario ha sido enviado con éxito.",
        icon: "success",
        confirmButtonText: "Ok",
      });
    } catch (error) {
      console.error("Hubo un error:", error);
      Swal.fire({
        title: "Error",
        text: "Hubo un problema al enviar tu comentario.",
        icon: "error",
        confirmButtonText: "Cerrar",
      });
    }
  };

  const { darkMode } = useContext(DarkModeContext);
  return (
    <section className="container">
      <form className="pb-0" onSubmit={onSubmit}>
        {/* escritorio */}
        <article className=" d-none d-lg-block">
          <div
            className={
              darkMode
                ? " contener-opinion-estrella-dark centrado-flex-around "
                : "contener-opinion-estrella centrado-flex-around "
            }
          >
            <div className="">
              <h6 className="lato-bold fs-20 ">
                Queremos saber tu opinión, ¿cómo calificarías el servicio <br />
                ofrecido por tu Asesor Consultor?
              </h6>
            </div>
            <section>
              <div>
                <div>
                  {[1, 2, 3, 4, 5].map((star) => (
                    <span
                      className="width-estrellas"
                      key={star}
                      onClick={() => handleStarClick(star)}
                      style={{
                        color: star <= rating ? "#b4c400" : "#343a40",
                      }}
                    >
                      <FontAwesomeIcon icon={faStar} />
                    </span>
                  ))}
                </div>
              </div>
            </section>
          </div>
        </article>
        {/* Celular */}
        <article className="d-lg-none d-block">
          <div
            className={
              darkMode
                ? " contenedor-opinion-estrella-mobile-dark py-5"
                : "contenedor-opinion-estrella-mobile py-5 "
            }
          >
            <div className=" ">
              <h6 className=" text-center fs-18  lato-bold d-md-block d-none">
                Queremos saber tu opinión, ¿cómo <br /> calificarías el servicio
                ofrecido por tu Asesor Consultor ?
              </h6>
              <h6 className=" text-center fs-16 lato-bold  d-block d-md-none">
                Queremos saber tu opinión, ¿cómo <br /> calificarías el servicio
                ofrecido <br /> por tu Asesor Consultor ?
              </h6>
            </div>
            <div className="text-center ">
              <section>
                <div>
                  <div>
                    {[1, 2, 3, 4, 5].map((star) => (
                      <span
                        className="width-estrellas mt-2"
                        key={star}
                        onClick={() => handleStarClick(star)}
                        style={{
                          color: star <= rating ? "#b4c400" : "#343a40",
                        }}
                      >
                        <FontAwesomeIcon icon={faStar} />
                      </span>
                    ))}
                  </div>
                </div>
              </section>
            </div>
          </div>
        </article>

        {/* escritorio */}
        <article className="py-3 my-3 mx-4 d-md-block d-none ">
          <h6>
            <span className="lato-bold fs-18 ">
              {" "}
              ¿Tenés algún comentario o sugerencia?
            </span>{" "}
            <br />
            <span className="lato-regular fs-18 ">
              Podés dejarlo en la siguiente caja y nos aseguraremos de tenerlo
              en cuenta para mejorar nuestro servicio:
            </span>
          </h6>
        </article>
        {/* celular */}
        <article className="py-4 mx-4 d-md-none d-block ">
          <div>
            <p>
              <span className="lato-bold fs-16 line-16">
                {" "}
                ¿Tenés algún comentario o sugerencia?{" "}
              </span>
              <br />
              <span className="lato-regular fs-16 line-16">
                Podés dejarlo en la siguiente caja y nos aseguraremos de tenerlo
                en cuenta para mejorar nuestro servicio:
              </span>
            </p>
          </div>
        </article>

        <div className="mb-3">
          <Form.Group as={Col} md="12" controlId="validationCustom01">
            <Form.Control
              as="textarea"
              className={
                darkMode
                  ? "form-control input-comentarios-calificar-dark border-0 px-5 py-4 text-white"
                  : "form-control input-comentarios-calificar  px-5 py-4 border-0 "
              }
              placeholder="Ingresá tu texto aquí."
              required
              type="text"
              name="comentario"
              value={formComentarioData.comentario}
              onChange={(e) => {
                // Limitar el texto a 500 caracteres
                if (e.target.value.length <= 500) {
                  setFormComentarioData({
                    ...formComentarioData,
                    comentario: e.target.value,
                  });
                }
              }}
            />
          </Form.Group>
        </div>
        <div className="my-4 d-flex justify-content-center">
          <button
            disabled={isButtonDisabled}
            className={
              isButtonDisabled
                ? "btn-enviar-comentario-disabled"
                : "btn-enviar-comentario"
            }
            type="submit"
          >
            <span className="lato-bold fs-18 text-white ">Enviar</span>
          </button>
        </div>
      </form>
    </section>
  );
};

export default FormComentarioCalificar;
