using CalculationLibrary.DataModels;

namespace CalculationLibrary
{
    public class ModelCalculation
    {
        public static OutputDataModel Calculate(InputDataModel inputData)
        {
            var output = new OutputDataModel
            {
                m = (inputData.RasTemM * 1000 * inputData.RasRas) / (inputData.RasTemG * 1000 * inputData.RasV * Math.PI * Math.Pow(inputData.RasD / 2, 2)),
                Y0 = (inputData.RasH * inputData.RasTepl) / (inputData.RasV * inputData.RasTemG * 1000),
                Y1 = (inputData.RasD * inputData.RasTm) / ((inputData.RasTemM + 273) * 1000 * inputData.RasTemG)
            };
            output.Y1_DOP = 1 - output.m * Math.Exp((output.m - 1) * output.Y0 / output.m);
            for (float i = 0; i <= inputData.RasH; i += 0.5f)
            {
                var tableRow = new RowModel
                {
                    Y = (inputData.RasTepl * i) / (inputData.RasV * inputData.RasTemG * 1000)
                };
                tableRow.RasH = i;
                tableRow.ExpY = 1 - Math.Exp(((output.m - 1) * tableRow.Y) / output.m);
                tableRow.MexpY = 1 - output.m * Math.Exp(((output.m - 1) * tableRow.Y) / output.m);
                tableRow.V = tableRow.ExpY / output.Y1_DOP;
                tableRow.O = tableRow.MexpY / output.Y1_DOP;
                var deltaT = inputData.RasTg - inputData.RasTm;
                tableRow.t = inputData.RasTm + deltaT * tableRow.V;
                tableRow.T = inputData.RasTm + deltaT * tableRow.O;
                tableRow.DeltaT = Math.Abs(tableRow.T - tableRow.t);
                output.RowModels.Add(tableRow);
            }
            return output;
        }
    }
}
