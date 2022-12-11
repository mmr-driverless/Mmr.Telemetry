import React from "react";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import Home from "./components/Home";
import * as FaIcons from "react-icons/fa"
import * as FiIcons from "react-icons/fi"
import * as AiIcons from "react-icons/ai"
import * as IoIcons from "react-icons/io5"

export const SidebarData = [
    {
        title: 'Home',
        index: true,
        path: '/',
        element: <Home />,
        icon: <AiIcons.AiOutlineHome/>,
        cName: 'nav-text'
    },
    {
        title: 'List',
        path: '/list',
        element: <FetchData />,
        icon: <AiIcons.AiOutlineUnorderedList/>,
        cName: 'nav-text'
    },
    {
        title: 'New',
        path: '/plot',
        element: <Counter />,
        icon: <AiIcons.AiOutlinePlus/>,
        cName: 'nav-text'
    },
    {
        title: 'Live',
        path: '/live',
        element: <Counter />,
        icon: <IoIcons.IoFlashOutline/>,
        cName: 'nav-text'
    },
    {
        title: 'Settings',
        path: '/sett',
        element: <Counter />,
        icon: <FiIcons.FiSettings/>,
        cName: 'nav-text'
    }
];
