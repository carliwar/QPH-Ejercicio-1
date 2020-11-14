using NSubstitute;
using NUnit.Framework;
using QPH.Eval.Ej1.Business;
using QPH.Eval.Ej1.Core;
using QPH.Eval.Ej1.Core.Models;
using System;

namespace QOPH.Eval.Ej1.Tests
{
    public class LibroBusinessTests
    {

        [Test]
        public void CreateLibro_LibroMayorA10Años_ReturnsValidacionError()
        {
            //Arrange
            var libroRepository = Substitute.For<ILibroRepository>();
            var libroBusiness = new LibrosBusiness(libroRepository);
            var libro = new Libro
            {
                FechaDePublicacion = new DateTime(2000,1,2)
            };
            
            //Act
            var result = libroBusiness.CreateLibro(libro);

            //Assert
            Assert.IsTrue(result.Errors.ContainsKey("Fecha De Publicación"));
        }
    }
}