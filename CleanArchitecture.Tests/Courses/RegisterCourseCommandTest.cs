using AutoMapper;
using CleanArchitecture.Application.CQRS.Courses.Commands.Register;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Type = CleanArchitecture.Domain.Enums.Type;

namespace CleanArchitecture.Tests.Courses
{
    public class RegisterCourseCommandTest
    {
        [Theory]
        [InlineData("Ensinando XUnit", Type.TI)]
        [InlineData("Ensinando Unit Tests", Type.TI )]
        public async Task RegisterCourseCommandIsValid_RegistedCourse_ReturnsSuccessMessage(string name, Type type)
        {
            //Expected
            var messageExpected = "Curso salvo com sucesso!";
            var objExpected = new Course
            {
                Name = name,
                Type = type
            };

            IResponse response = new Response
            {
                hasError = false,
                collections = null,
                ErrorMessages = new List<string>(),
                message = "O Curso foi salvo com sucesso!"
            };

            //Arrange

            var mockRepository = new Mock<ICourseRepository>();
            mockRepository.Setup(x => x.Add(It.IsAny<Course>())).Returns(Task.FromResult(1));
            mockRepository.Setup(x => x.Any(It.IsAny<Expression<Func<Course, bool>>>())).Returns(Task.FromResult(false));
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Course>(It.IsAny<RegisterCourseCommand>())).Returns(objExpected);
            var mockResponse = new Mock<IResponse>();
            mockResponse.Setup(x => x.Generate(It.IsAny<object>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<List<string>>())).Returns(Task.FromResult(response));

            var command = new RegisterCourseCommand
            {
                Name = name,
                Type = type
            };

            var handler = new RegisterCourseHandler(mockMapper.Object, mockRepository.Object, mockResponse.Object);

            //Act

            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.message);
            Assert.False(result.hasError);
            Assert.Equal(result.message, messageExpected);
            Assert.IsType<Response>(result);
        }


    }
}
