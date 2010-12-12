// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2010.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace Samples

[<AutoOpen>]
module JQueryExtensions =
    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.JQuery

    type IntelliFactory.WebSharper.Html.Element with
        [<JavaScript>]
        member self.JQuery = JQuery.Of self.Dom

#nowarn "191"

/// Used to refer to this assembly.
type Marker = class end
