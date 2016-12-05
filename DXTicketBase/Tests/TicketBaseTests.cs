﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase {
    [TestFixture]
    public class TicketBaseTests {
        [Test]
        public void ParseQuestion6() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"Q123123: test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "Q123123");
        }
        [Test]
        public void ParseQuestion5() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"Q12313: test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "Q12313");
        }
        [Test]
        public void ParseQuestion4() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"Q1231: test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "Q1231");
        }
        [Test]
        public void ParseTQuestion() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"T123144: test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "T123144");
        }
        [Test]
        public void ParseExample() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"E1234: test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "E1234");
        }
        [Test]
        public void ParseWrongSubject0() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"E1234:test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "E1234");
        }
        [Test]
        public void ParseWrongSubject1() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"T123123:test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, "T123123");
        }
            [Test]
        public void ParseWrongSubject2() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"123123: test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, null);
        }
            [Test]
        public void ParseWrongSubject3() {
            MyTicket tkt = new MyTicket(new Ticket());
            tkt.ComplexSubject = @"123123:test";
            tkt.ParseComplexSubject();
            Assert.AreEqual(tkt.Number, null);
        }

    }
}
