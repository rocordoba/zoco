import { useContext } from "react";
import ContenidoLogin from "../components/ContenidoLogin";
import FooterLogin from "../components/FooterLogin";
import { DatosInicioContext } from "../context/DatosInicioContext";
import ContenidoLoginNew from "../components/ContenidoLoginNew";

const Login = () => {
  const {
    onSubmit,
    datosMandados,
    setDatosMandados,
    setIsLoading,
    setButtonText,
    isLoading,
    buttonTex,
  } = useContext(DatosInicioContext);
  return (
    <section className="bg-view-login ">
      <article className="">
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "100vh",
          }}
        >
          {/* <ContenidoLoginNew datosMandados={datosMandados}
            setDatosMandados={setDatosMandados} /> */}
          <ContenidoLogin
            onSubmit={onSubmit}
            datosMandados={datosMandados}
            setDatosMandados={setDatosMandados}
            setIsLoading={setIsLoading}
            setButtonText={setButtonText}
            isLoading={isLoading}
            buttonTex={buttonTex}
          />
        </div>
      </article>
      <div className="d-flex justify-content-center">
        <FooterLogin />
      </div>
    </section>
  );
};

export default Login;
