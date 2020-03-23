using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlashcardsUnitTests
{
    public class SessionTests
    {
        [Fact]
        public void Test1()
        {
            Box session = new Box();
            session.Containers.Add(new Container(20));
            session.Containers.Add(new Container(40));
            session.Containers.Add(new Container(60));
            session.Containers.Add(new Container(80));
            session.Containers.Add(new Container(100));

            Card card1 = new Card(1, "1", "1", 1);
            Card card2 = new Card(2, "2", "2", 1);
            Card card3 = new Card(3, "3", "3", 2);
            Card card4 = new Card(4, "4", "4", 2);
            Card card5 = new Card(5, "5", "5", 3);
            Card card6 = new Card(6, "6", "6", 3);
            Card card7 = new Card(7, "7", "7", 3);

            IEnumerator enumerator = session.Containers.GetEnumerator();

            enumerator.MoveNext();
            Container c = (Container)enumerator.Current;
            c.Cards.Add(card1);
            c.Cards.Add(card1);

            Assert.Single(c.Cards);





        }
    }
}
