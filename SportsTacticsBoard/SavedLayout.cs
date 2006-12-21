// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006 Robert Turner
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsTacticsBoard
{
  class SavedLayout
  {
    private string fieldTypeTag;
    private string name;
    private string category;
    private string description;
    private FieldObjectLayout layout;

    public string FieldTypeTag
    {
      get { return fieldTypeTag; }
    }

    public string Name
    {
      get { return name; }
    }

    public string Category
    {
      get { return category; }
    }

    public string Description
    {
      get { return description; }
    }

    public FieldObjectLayout Layout
    {
      get { return layout; }
    }

    public SavedLayout()
    {
      name = "";
      category = "";
      description = "";
      layout = new FieldObjectLayout();
      fieldTypeTag = "";
    }

    public SavedLayout(string _name, string _category, string _description, FieldObjectLayout _layout, string _fieldTypeTag)
    {
      name = _name;
      category = _category;
      description = _description;
      layout = _layout;
      fieldTypeTag = _fieldTypeTag;
    }
  }
}
