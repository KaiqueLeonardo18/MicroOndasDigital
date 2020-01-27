using MicroOndasDigital.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MicroOndasTeste
{
    [TestClass]
    public class MicroOndasTeste
    {
        [TestMethod]
        public void TempoTeste()
        {
            try
            {
                MicroOndasService.TempoValido("0");
            }
            catch (Exception e)
            {
                if (e.Message != "Insira um tempo entre 1 segundo e dois minutos")
                    Assert.Fail();
            }
            try
            {
                MicroOndasService.TempoValido("121");
            }
            catch (Exception e)
            {
                if (e.Message != "Insira um tempo entre 1 segundo e dois minutos")
                    Assert.Fail();
            }
            try
            {
                MicroOndasService.TempoValido("");
            }
            catch (Exception e)
            {
                if (e.Message != "Por favor, Digite um tempo valido.")
                    Assert.Fail();
            }
            Assert.AreEqual(4, MicroOndasService.TempoValido("4"));
        }

        [TestMethod]
        public void PotenciaTeste()
        {
            try
            {
                MicroOndasService.PotenciaValida("0");
            }
            catch (Exception e)
            {
                if (e.Message != "Insira uma potencia entre 1 e 10")
                    Assert.Fail();
            }
            try
            {
                MicroOndasService.PotenciaValida("11");
            }
            catch (Exception e)
            {
                if (e.Message != "Insira uma potencia entre 1 e 10")
                    Assert.Fail();
            }
            Assert.AreEqual(10, MicroOndasService.PotenciaValida(""));
            Assert.AreEqual(4, MicroOndasService.PotenciaValida("4"));

        }
    }
}
