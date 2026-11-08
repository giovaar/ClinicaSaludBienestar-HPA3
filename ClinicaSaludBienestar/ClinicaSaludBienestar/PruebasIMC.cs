
using System;

namespace ClinicaSaludBienestar
{
    public static class PruebasIMC
    {
        // Calcular tendencia
        public static string CalcularTendencia(
            decimal imcInicial, decimal imcFinal)
        {
            decimal diferencia = imcFinal - imcInicial;

            if (diferencia > 0.5m)
                return "Sube";

            if (diferencia < -0.5m)
                return "Baja";

            return "Estable";
        }

        // Ejecutar pruebas
        public static string Ejecutar()
        {
            string resultado = "";

            resultado += Probar(20.0m, 20.5m, "Estable");
            resultado += Probar(20.0m, 19.5m, "Estable");
            resultado += Probar(20.0m, 20.6m, "Sube");
            resultado += Probar(20.0m, 19.4m, "Baja");
            resultado += Probar(20.0m, 20.0m, "Estable");

            return resultado;
        }

        private static string Probar(
            decimal inicial,
            decimal final,
            string esperado)
        {
            string obtenido =
                CalcularTendencia(inicial, final);

            string estado = obtenido == esperado
                ? "CORRECTO"
                : "ERROR";

            return "Inicial: " + inicial +
                   " | Final: " + final +
                   " | Esperado: " + esperado +
                   " | Obtenido: " + obtenido +
                   " | " + estado +
                   Environment.NewLine;
        }
    }
}
