import { faStar } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useContext, useState } from "react";
import { useForm } from "react-hook-form";
import { DarkModeContext } from "../context/DarkModeContext";
import "./FormComentarioCalificar.css";
import { Col, Form } from "react-bootstrap";

const FormComentarioCalificar = () => {
  const [rating, setRating] = useState(0);
  const [formComentarioData, setFormComentarioData] = useState({
    comentario: "",
  });


    

  const handleInputChange = (event) => {
    event.preventDefault();
    const { name, value } = event.target;
    setFormComentarioData({ ...formComentarioData, [name]: value });
  };

  //const onSubmit = (event) => {
  //  event.preventDefault();
  //  const datosConRating = { ...formComentarioData, rating };
  //  setRating(0);
  //  setFormComentarioData({ comentario: "" });
  //};


  const handleStarClick = (star) => {
    setRating(star);
  };
    const onSubmit = async (event) => {
        event.preventDefault();
        const token = localStorage.getItem("token");
        const userId = parseInt(localStorage.getItem("userId")); // Asegúrate de que userId sea un entero
        const fechaActual = new Date().toISOString();

        const datosConRating = {
            Token: token,
            UsuarioId: userId,
            NumCalifico: rating,
            Descripcion: formComentarioData.comentario,
            Fecha: fechaActual
        };

        console.log("Datos a enviar:", datosConRating);

        try {
            const response = await fetch('/api/califico/califico', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(datosConRating),
            });

            if (!response.ok) {
                throw new Error('Error al enviar los datos');
            }

            const data = await response.json();
            // Hacer algo con la respuesta de la API si es necesario

            setRating(0);
            setFormComentarioData({ comentario: "" });
        } catch (error) {
            console.error('Hubo un error:', error);
            // Manejar el error adecuadamente
        }
    };
  const { darkMode } = useContext(DarkModeContext);
  return (
    <section className="container">
      <form className="pb-0 pb-lg-5" onSubmit={onSubmit}>
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
              onChange={handleInputChange}
            />
          </Form.Group>
        </div>
        <div className="my-4 d-flex justify-content-center">
          <button className="btn-enviar-comentario" type="submit">
            <span className="lato-bold fs-18 text-white ">Enviar</span>
          </button>
        </div>
      </form>
    </section>
  );
};

export default FormComentarioCalificar;
