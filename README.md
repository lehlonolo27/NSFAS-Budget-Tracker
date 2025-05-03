# 💸 NSFAS Budget & Allowance Tracker for Students

A **student-focused personal finance application** built with **ASP.NET Core Web API** and **Blazor WebAssembly**, designed specifically for South African students receiving **NSFAS** funding. This tool empowers students to manage their monthly allowances responsibly and stay on track financially.

---

## 🎯 Problem It Solves

Many South African students receiving **NSFAS allowances** struggle with:
- Overspending before month-end
- Tracking where their money goes
- Lack of financial tools designed for their unique needs

This app fills that gap with an easy-to-use, mobile-friendly budgeting solution tailored to **NSFAS recipients**.

---

## 🚀 Features

- 🔐 Secure login and registration (JWT auth)
- 🧾 Track monthly allowance spending by category:
  - 📚 Textbooks
  - 🚌 Transport
  - 🍔 Food
  - 🏡 Rent (optional)
- 🟢🟡🔴 **Real-Time Budget Health Indicator**  
  See instantly if you’re within budget (green), approaching limit (yellow), or over (red).
- 📲 **SMS Alerts for Overspending** (mocked with Twilio or console)
- 💾 **Offline-First Support**  
  Save and view budgets even without internet using IndexedDB/local storage

---

## 🛠️ Tech Stack

| Layer        | Technology                            |
|--------------|---------------------------------------|
| Backend API  | ASP.NET Core Web API (.NET 7)         |
| Frontend     | Blazor WebAssembly                    |
| Database     | MS SQL Server + Entity Framework Core |
| Auth         | JWT Tokens                            |
| UI Framework | Bootstrap or Blazorise                |
| Extras       | Twilio API (SMS mock), IndexedDB      |

---

## 🧑‍💻 How to Run Locally

### Prerequisites

- .NET 7 SDK  
- Visual Studio Code  
- SQL Server (LocalDB or SQL Server Express)  
- Twilio account for SMS simulation (optional)

---

### Backend API Setup & Frontend Blazor Setup

cd NSFASBudgetTracker.API
dotnet restore
dotnet ef database update
dotnet run

### Frontend Blazor Setup
bash
cd NSFASBudgetTracker.Client
dotnet restore
dotnet run

🧠 How the App Works

🔐 Register or log in as a student.

💸 Input your monthly NSFAS allowance.

🧾 Add budget entries by category (e.g., Food, Transport).

🌡️ App will display your spending health (green/yellow/red).

🔔 If overspending, you’ll get a mock SMS alert.

💻 Even without data/internet, recent data is cached locally.

🔮 Future Improvements
📈 Budget trend analytics (month-to-month comparison)

💳 Support for bank statement uploads or NSFAS API (if available)

🧪 Unit tests and e2e testing (Playwright or bUnit)

📱 Convert to PWA for installable mobile experience

🌍 Why It Stands Out
🎯 Built specifically for South African students receiving NSFAS funding

🛡️ Uses secure modern web stack (ASP.NET Core + Blazor)

💡 Focused on financial literacy and responsible allowance use

🆓 100% free and accessible

