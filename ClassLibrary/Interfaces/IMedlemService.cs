﻿using ClassLibrary.Models;

namespace ClassLibrary.Interfaces;

public interface IMedlemService
{
    List<Medlem> GetMedlemmer();
    void AddMedlem(Medlem medlem);
    void UpdateMedlem(Medlem medlem);
    Medlem GetMedlem(string email);
    Medlem DeleteMedlem(string? email);
}
