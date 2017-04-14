using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class ExpressionTests
    {

        [TestMethod]
        public void SimpleExpressionCompile()
        {
            Expression<Func<int, int, int, bool>> betweenExclusiveExpression = (start, end, input) => start < input && end > input;
            Func<int, int, int, bool> resultFunc = betweenExclusiveExpression.Compile();
            Assert.IsTrue(resultFunc.Invoke(1, 10, 5));
            Assert.IsTrue(resultFunc(1, 10, 5));
            Assert.IsFalse(resultFunc(1, 10, 10));
        }

        [TestMethod]
        public void ExpressionTreeAssign()
        {
            var inputValue = Expression.Parameter(typeof(int), "inputValue");
            var resultValue = Expression.Parameter(typeof(int), "resultValue");

            BlockExpression block = Expression.Block(
                new[] { resultValue },
                Expression.Assign(resultValue, inputValue)
            );

            // Compile and execute an expression tree.  
            var value = Expression.Lambda<Func<int, int>>(block, inputValue).Compile()(999);
            Assert.AreEqual(999, value);
        }

        [TestMethod]
        public void ExpressionTreeAdd()
        {
            var inputValue1 = Expression.Parameter(typeof(int), "inputValue1");
            var inputValue2 = Expression.Parameter(typeof(int), "inputValue2");
            var resultValue = Expression.Parameter(typeof(int), "resultValue");

            var block1 = Expression.Block(
                new[] { resultValue },
                Expression.Assign(resultValue, Expression.Add(inputValue1, inputValue2))
            );

            var block2 = Expression.Block(
                new[] { resultValue },
                Expression.Assign(resultValue, Expression.Add(inputValue1, resultValue)),
                Expression.Assign(resultValue, Expression.Add(inputValue2, resultValue))
            );

            var value1 = Expression.Lambda<Func<int, int, int>>(block1, inputValue1, inputValue2).Compile()(3, 7);
            Assert.AreEqual(10, value1);

            var value2 = Expression.Lambda<Func<int, int, int>>(block2, inputValue1, inputValue2).Compile()(3, 7);
            Assert.AreEqual(10, value2);
        }

        //[TestMethod]
        //public void ExpressionTreeList()
        //{
        //    var inputValue = Expression.Parameter(typeof(int), "inputValue");
        //    var result = Expression.Parameter(typeof(List<int>), "result");

        //    string[] fields = { "Name", "Test_Result" };
        //    var listAddMethod = typeof(List<int>).GetMethod(
        //        "Add", new[] {typeof(int)});
        //    var selector = Expression.ListInit(
        //            Expression.New(typeof(Dictionary<string, object>)),
        //            fields.Select(field => Expression.ElementInit(listAddMethod,
        //                Expression.Constant(field),
        //                Expression.Convert(Expression.PropertyOrField(itemParam, field),typeof(object))
        //            )));


        //    var block = Expression.Block(
        //        new[] { result },
        //        Expression.ListInit(
        //            Expression.New(typeof(List<int>)),
        //            )

        //    );

        //    var value1 = Expression.Lambda<Func<int, int>>(block, inputValue).Compile()(1);
        //    Assert.AreEqual(10, value1);
        //}

        //[TestMethod]
        //public void ExpressionTreeLoop()
        //{

        //    var inputValue = Expression.Parameter(typeof(int), "inputValue1");

        //    var result = Expression.Parameter(typeof(List<int>), "result");

        //    var label = Expression.Label(typeof(int));

        //    var block = Expression.Block(
        //        new[] { result },
        //        Expression.Assign(result, Expression.Constant(1)),
        //            Expression.Loop(
        //               // Adding a conditional block into the loop.  
        //               Expression.IfThenElse(
        //                   // Condition: value > 1  
        //                   Expression.GreaterThan(inputValue, Expression.Constant(1)),
        //                   // If true: result *= value --  
        //                   Expression.MultiplyAssign(result, Expression.PostDecrementAssign(inputValue)),
        //                   // If false, exit the loop and go to the label.  
        //                   Expression.Break(label, result)
        //               ),
        //           // Label to jump to.  
        //           label
        //        )
        //    );

        //    // Compile and execute an expression tree.  
        //    int factorial = Expression.Lambda<Func<int, int>>(block, inputValue).Compile()(5);
        //}

        //[TestMethod]
        //public void aaExpressionTreeCreateTest()
        //{
        //    // Creating a parameter expression.  
        //    ParameterExpression value = Expression.Parameter(typeof(int), "value");

        //    // Creating an expression to hold a local variable.   
        //    ParameterExpression result = Expression.Parameter(typeof(int), "result");

        //    // Creating a label to jump to from a loop.  
        //    LabelTarget label = Expression.Label(typeof(int));

        //    // Creating a method body.  
        //    BlockExpression block = Expression.Block(
        //        // Adding a local variable.  
        //        new[] { result },
        //        // Assigning a constant to a local variable: result = 1  
        //        Expression.Assign(result, Expression.Constant(1)),
        //            // Adding a loop.  
        //            Expression.Loop(
        //               // Adding a conditional block into the loop.  
        //               Expression.IfThenElse(
        //                   // Condition: value > 1  
        //                   Expression.GreaterThan(value, Expression.Constant(1)),
        //                   // If true: result *= value --  
        //                   Expression.MultiplyAssign(result,
        //                       Expression.PostDecrementAssign(value)),
        //                   // If false, exit the loop and go to the label.  
        //                   Expression.Break(label, result)
        //               ),
        //           // Label to jump to.  
        //           label
        //        )
        //    );

        //    // Compile and execute an expression tree.  
        //    int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);
        //}

    }
}
