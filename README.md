# 🔍 Search Engine MVC Web Application

A simple yet powerful search engine web app built using ASP.NET MVC. The application allows users to perform keyword-based searches on a set of documents. Results are ranked either by frequency of the keywords or by a custom scoring rank — as chosen by the user.

--- 

## 📌 Features

- 🔎 Keyword-based document search
- 📈 Two ranking modes:
  - **Word Count**: Results ordered by number of keyword occurrences.
  - **Custom Rank**: Based on a scoring algorithm defined during data preprocessing.
- 🧠 Data automatically scraped and stored in a SQL Server database.
- 🧰 Clean MVC architecture with separation of concerns.
- 🎯 Real-time suggestions while typing (optional future enhancement).
- 💡 Simple UI using Bootstrap.

---

## 🛠️ Technologies Used

- **ASP.NET MVC (C#)**
- **SQL Server**
- **Entity Framework**
- **LINQ**
- **HTML / CSS / Bootstrap**

---

## 🧰 Database Structure

The database is populated with data gathered via scraping. It includes:

- `Documents`: ID, Title, Content, Source URL
- `Words`: Word ID, Word Text
- `DocumentWords`: Many-to-many relationship with word counts
- Optional: Rank Score column for advanced sorting

---

## ⚙️ Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET Framework or .NET Core SDK (depending on your setup)
- SQL Server (LocalDB or Express)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/GannaGamal/Search-Engine-MVC.git
   cd Search-Engine-MVC
