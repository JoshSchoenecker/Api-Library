using System;
using System.Collections.Generic;
using apiLibrary.DB;
using Microsoft.AspNetCore.Mvc;

namespace apiLibrary
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class DrinkController : ControllerBase
    {

// NOTE Get Requests
    // Get all drinks
    [HttpGet]
    public ActionResult<IEnumerable<Drink>> GetAll()
    {
        try
        {
            return Ok(FakeDB.Drinks);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    // Get a drink by Id
    [HttpGet("{drinkId}")]
    public ActionResult<IEnumerable<Drink>> GetOne(string drinkId)
    {
        try
        {
            Drink selectedDrink = FakeDB.Drinks.Find(drink => drink.Id == drinkId);
            // don't forget to hanle null!
            if (selectedDrink == null)
            {
                throw new Exception("Invalid ID!");
            }
            return Ok(selectedDrink);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);            
        }
    }
// NOTE Post Request
    [HttpPost]
    public ActionResult<Drink> Create([FromBody] Drink newDrink)
    {
        try
        {
            FakeDB.Drinks.Add(newDrink);
            return Created($"api/drinks/{newDrink.Id}", newDrink);
        }
        catch (System.Exception err)
        {
         return BadRequest(err.Message);
        }
    }
// NOTE Put Request
    [HttpPut("{drinkId}")]
    public ActionResult<Drink> Edit(string drinkId, [FromBody] Drink updatedDrink)
    {
        try
        {
            Drink updateQueue = FakeDB.Drinks.Find(drink => drink.Id == drinkId);
            if (updateQueue == null)
            {
                throw new Exception("Invalid ID!");
            }
            return Ok(updateQueue);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
// NOTE Delete Request
    [HttpDelete("{drinkId}")]
    public ActionResult<Drink> Delete(string drinkId)
    {
        try
        {
            Drink drinkToUpdate = FakeDB.Drinks.Find(drink => drink.Id == drinkId);
            if (drinkToUpdate == null)
            {
                throw new Exception("Invalid ID!");
            }
            return Ok("Drink Deleted");
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    }

}